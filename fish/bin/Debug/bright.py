# -*- coding=utf8 -*-
import cv2 as cv
import numpy as np
import sys
import saveImg
 
 
def contrast_brightness_image(src1, a, g):
    h, w, ch = src1.shape
    src2 = np.zeros([h, w, ch], src1.dtype)
    dst = cv.addWeighted(src1, a, src2, 1-a, g)
    return dst
 
if __name__=="__main__":
	src = cv.imread(sys.argv[1])
	dst = contrast_brightness_image(src, 1.2, 10)
	saveImg.saveImage(sys.argv[1],dst)