# -*- coding: UTF-8 -*-
import cv2
import time

def saveImage(fileUrl,img):
	filename = fileUrl.split('\\')[-1]
	savePath = "E:/pics/after/"+filename.split('.')[0]+str(int(time.time()))+"."+filename.split('.')[1]
	cv2.imwrite(savePath,img)
	print(savePath)
