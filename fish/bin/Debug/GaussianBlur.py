# -*- coding: UTF-8 -*-
import cv2
import sys
import numpy
import saveImg

if __name__ == '__main__':
	img = cv2.imread(sys.argv[1])
	kernel_size = (5, 5)
	sigma = 1.5
	new_img = cv2.GaussianBlur(img, kernel_size, sigma)

	saveImg.saveImage(sys.argv[1],new_img)