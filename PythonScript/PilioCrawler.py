# -*- coding: utf-8 -*-
# Created by Keoy7am
# Date: 2019/04/28
# Time: 02:30
# TargetSite: https://www.pilio.idv.tw/ltobig/list.asp
# Github: https://github.com/keoy7am/LottoCrawler
import os
from bs4 import BeautifulSoup
import requests
import csv
import time
from subprocess import call
import sys
reload(sys)
sys.setdefaultencoding('utf-8')

domain = "https://www.pilio.idv.tw/ltobig/list.asp"

data = []
data.append(["日期","中獎號碼","特別號"])

def progress(num, total):
    rate = float(num) / float(total)
    rate_num = int(rate * 100)
    r = '\r[%s%s] 完成度 %d%%, 更新至第 %d 頁' % ("="*rate_num, " "*(100-rate_num), rate_num, num )
    sys.stdout.write(r)
    sys.stdout.flush()
    if(rate_num==100):
		print "\r"

def main():
	count = getPageCount()
	getAllData(count)
	exportCSV()
def getPageCount():
	res = requests.get(domain, timeout = 30)
	soup = BeautifulSoup(res.text, "lxml")
	count = soup.select("a")[31].get('href').replace('list.asp?indexpage=','').replace('&orderby=new','')
	print '總頁數:' + count
	return count
def getAllData(count):
	for i in range(1 , int(count) +1):
		getData(i)
		progress(i,int(count))
		time.sleep(0.01)
def getData(index):
	res = requests.get(domain + '?indexpage=' + str(index) +'&orderby=new', timeout = 30)
	soup = BeautifulSoup(res.text, "lxml")
	result = soup.select('.auto-style1>tr')
	del result[0] # Remove Row Header
	for re in result:
			dataQuery = re.select('td')
			rawDate = dataQuery[0].text
			date = rawDate[:4] + '/' + rawDate[4:].split('(')[0]
			nums  = dataQuery[1].text.strip()
			special = dataQuery[2].text.strip()
			data.append([date,nums,special])
			# print '--------------------'
			# print ' 日期： ' + date + ' 開獎號： ' + nums + ' 特別號： ' + special
def exportCSV():
	with open("lotto.csv", "wb") as f:
		w = csv.writer(f)
		w.writerows(data)

if __name__ == "__main__":
	main()
