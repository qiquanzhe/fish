# -*- coding: UTF-8 -*-
import cv2
import numpy
import sys
import saveImg

if __name__ == '__main__':
	img = cv2.imread(sys.argv[1],0)
	saveImg.saveImage(sys.argv[1],cv2.Canny(img,200,300))