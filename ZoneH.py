import requests #, http.client, urllib
# import socket
from platform import system
import os
import sys, time
import re
# import threading
from multiprocessing import Pool
from colorama import Fore
from colorama import Style
from colorama import init
# importing webdriver from selenium
from PIL import Image
from selenium import webdriver
from selenium.webdriver.chrome.options import Options
from selenium.webdriver.chrome.service import Service
from webdriver_manager.chrome import ChromeDriverManager
import undetected_chromedriver as uc
from selenium.webdriver.common.by import By
from functools import *
from concurrent.futures import ThreadPoolExecutor
from random import sample
import subprocess
from itertools import repeat

init(autoreset=True)
fr  =   Fore.RED
fh  =   Fore.RED
fc  =   Fore.CYAN
fo  =   Fore.MAGENTA
fw  =   Fore.WHITE
fy  =   Fore.YELLOW
fbl =   Fore.BLUE
fg  =   Fore.GREEN
sd  =   Style.DIM
fb  =   Fore.RESET
sn  =   Style.NORMAL
sb  =   Style.BRIGHT

user = {"User-Agent": "Mozilla/5.0 (Windows NT 6.1; rv:57.0) Gecko/20100101 Firefox/57.0"}
archive_url = "http://www.zone-h.org/archive/special=1"
onhold_url = "http://www.zone-h.org/archive/published=0"

save_loc = "./Defaced/"

def get_driver(url: str="zone-h"):
	if url == "zone-h":
		options = Options()
		options.add_argument("--headless") # Runs Chrome in headless mode.
		options.add_argument('--no-sandbox') # # Bypass OS security model
		options.add_argument('start-maximized')
		options.add_argument('disable-infobars')
		options.add_argument("--disable-extensions")
		options.add_argument("--window-size=1440x900")
		options.add_argument(f'user-agent={user}')
		# options.add_argument('--force-device-scale-factor=1')
		# options.add_argument("--enable-javascript")
		# options.add_experimental_option("excludeSwitches", ["enable-automation"])
		# options.add_experimental_option('useAutomationExtension', False)
		# options.add_argument('--disable-blink-features=AutomationControlled')
		return webdriver.Chrome(service=Service(ChromeDriverManager().install()), options=options)
	
	options = uc.ChromeOptions()
	options.add_argument("--headless") # Runs Chrome in headless mode.
	options.add_argument("--window-size=1440x900")
	return uc.Chrome(use_subprocess=True, options=options)

def report_slots(base, mode="empty"):
	ind, fcount, res, files = 1, 0, [], []
	for filename in os.listdir(save_loc):
		file_ind = int(filename[5:-4])
		files.append(file_ind)
	files.sort()

	for file_ind in files:
		if file_ind > base+(ind-1)*25 and file_ind <= base+ind*25:
			fcount += 1
		elif file_ind > base+ind*25:
			if mode == 'empty' and fcount <= 15: # if >= 16 images in ind range then report
				res.append(ind)
			if mode == 'filled' and fcount >= 16: # if <= 15 images in ind range then report
				res.append(ind)
			ind += 1
			fcount = 1
	return res

def safe_print(*args, sep=" ", end="", **kwargs):
	joined_string = sep.join([ str(arg) for arg in args ])
	print(joined_string  + "\n", sep=sep, end=end, **kwargs)

def get_cookie(driver):
	res, cookiez = {}, driver.get_cookies()
	for dicc in cookiez:
		if dicc['name'] == 'ZHE':
			res["ZHE"] = dicc['value']
		if dicc['name'] == 'PHPSESSID':
			res["PHPSESSID"] = dicc['value']
	return res

def add_cookies(driver, cookies):
	if cookies is None:
		raise Exception("Empty cookies")
	for cookie in cookies:
		driver.add_cookie(cookie)

def handle_captcha(driver, mirror, i):
	try:
		captcha_repo_link = "./Ardin.ZoneHCaptchaSolver/"
		captcha_dest = captcha_repo_link+f"CaptchaSamples/captcha{i}.png"
		captcha_solver = captcha_repo_link+"Ardin.ZoneHCaptchaSolver.Sample/Ardin.ZoneHCaptchaSolver.Sample.csproj"

		driver.get(mirror)

		while True:
			response = requests.get("https://www.zone-h.org/captcha.py", cookies=get_cookie(driver))
			with open(captcha_dest, "wb") as f:
				f.write(response.content)
			# run the captcha solver until it's correct
			subprocess.run(["dotnet", "run", "--project", captcha_solver, str(i)])

			content = open("Res.txt", 'r').read()
			print(content)
			form = driver.find_element(By.XPATH, "//input[@name='captcha']")
			form.send_keys(content)
			submit = driver.find_element(By.XPATH, "//input[@type='submit']")
			submit.click()

			try: # check if still captcha
				driver.find_element(By.XPATH, "//input[@name='captcha']")
			except:
				# no captcha, return
				return
	except Exception as e:
		print(e)
		driver.quit()
		sys.exit()

def login(driver):
	login_info = open('credentials.txt', 'r').readlines()
	# print(login_info)
	username = driver.find_element(By.ID, "login")
	password = driver.find_element(By.ID, "password")
	username.send_keys(login_info[0][:-1]) # the last char is newline
	password.send_keys(login_info[1])

	submit = driver.find_element(By.XPATH, "//input[@type='submit']")
	submit.click()

def connect(i):
	while True:
		try:
			driver = get_driver("undetected-chrome")
			# driver = get_driver()
			driver.get("http://www.zone-h.org/login")
			# time.sleep(3)
			login(driver)
			break
		except Exception as e:
			safe_print(f'[{i}] '+str(e))
			driver.quit()
			# sys.exit()
	cookie = get_cookie(driver)
	return driver, cookie

def crawl_zone_h(i, base, crawl_url, driver, cookie):
	filled = report_slots(base, "filled")
	while i < 51:
		if i in filled:
			i += 10
			continue

		mirror = crawl_url +"/page=" + str(i)
		dz = requests.get(mirror, cookies=cookie)
		# time.sleep(3)
		dzz = dz.content.decode("utf-8")
		safe_print(f'[{i}] '+mirror)

		if '<html><body>-<script type="text/javascript"' in dzz:
			# print(dzz)
			safe_print(f'[{i}] '+"Onii Chan Please Enter Cookie")
			driver.quit()
			sys.exit()
		if '<input type="text" name="captcha" value=""><input type="submit">' in dzz:
			safe_print(f'[{i}] '+"Onii Chan Please Change Captcha In Zone-H")
			handle_captcha(driver, mirror, i)

		Hunt_urls = re.findall('"/mirror/id/.*?"', dzz)
		if len(Hunt_urls) == 0:
			safe_print(f'[{i}] '+"Grabb Sites continue Onii Chan ()> _ <)")
			continue
		
		for j, url in enumerate(Hunt_urls):
			# qqq = xx.replace('...','')
			# print('    ['  + '*' + '] ' + xx[1:-1])
			mirror = "http://www.zone-h.org" + url[1:-1]
			dr = requests.get(mirror, cookies=cookie)
			drr = dr.content.decode("utf-8")
			
			if '<input type="text" name="captcha" value=""><input type="submit">' in drr:
				safe_print(f'[{i}] '+"Onii Chan Please save me from captcha (T ^ T )")
				# solve captcha using Machine Learning
				handle_captcha(driver, mirror, i)
				dr = requests.get(mirror, cookies=cookie)
				drr = dr.content.decode("utf-8")
			try:
				real_mirror = re.search('iframe src=\n".*?"', drr).group()[13:-1]
			except:
				continue
			safe_print(f'[{i}] '+real_mirror)
			driver.get(real_mirror)
			driver.save_screenshot(save_loc+"image"+str(base+(i-1)*25+j+1)+".png")
			# with open("Res" + '.txt', 'w') as rr:
			# 	rr.write(mirror+'\n')
		i += 10

def zone_h(i, base, crawl_url):
	# initiate sus driver to handle different websites
	driver, cookie = connect(i)
	
	try:
		crawl_zone_h(i, base, crawl_url, driver, cookie)
	except Exception as e:
		safe_print(f'[{i}] '+str(e))
		driver.quit()
		sys.exit()
	finally:
		driver.quit()

def clearscrn():
	if system() == 'Linux':
		os.system('clear')
	if system() == 'Windows':
		os.system('cls')
		os.system('color a')
# clearscrn()

def slowprint(s):
	for c in s + '\n':
		sys.stdout.write(c)
		sys.stdout.flush()
		time.sleep(4. / 100)

def grabber():
	print("""
		|---| Grabb Sites From Zone-h |--|
		\033[91m[1] \033[95mGrabb Sites By Archive
		\033[91m[2] \033[95mGrabb Sites By Onhold
		""")
	mode = input("\033[95mEnter crawl mode: \033[92m")
	if mode == '1': # archive 
		base, url = 0, archive_url
	elif mode == '2':
		base, url = 1250, onhold_url
	else:
		raise Exception("Wrong mode")
		
	num_cpu = 10
	# slots = report_slots(base)
	# starts = sample(slots, num_cpu)
	starts = range(1,num_cpu+1)

	# pool = Pool(os.cpu_count()) # Create a multiprocessing Pool
	# pool.starmap(zone_h, [(start, base, url) for start in starts]) 
	
	with ThreadPoolExecutor(max_workers=os.cpu_count()) as executor:
		executor.map(zone_h, starts, repeat(base), repeat(url))
	# 	# results = [item for block in bucket for item in block]

def helper4():
	clearscrn()
	banner = """\033[33m\033[91m\033[93m
	==========================================================
	=======================duy.le1201=========================
	=Author : LoliC0d3	Telegram : t.me/LoliC0d3	 =
	=Team   : PhobiaXploit	Facebook : Facebook.com/LoliC0d3 =
	==========================================================
"""
	print("""\033[91m
	==========================================================
	=======================duy.le1201=========================
	=Author : LoliC0d3	Telegram : t.me/LoliC0d3  	 =
	=Team   : PhobiaXploit	Facebook : Facebook.com/LoliC0d3 =
	==========================================================
	[+]1. Zone-H Grabber
			""")
	# print(report_slots(1250, "filled"))
	# return
	try:
		clearscrn()
		print(banner)
		grabber()

	except Exception as e:
		print(e)
	
if __name__ == '__main__':
	helper4()