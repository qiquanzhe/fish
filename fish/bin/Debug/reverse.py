# -*- coding=utf8 -*-
import sys
import cv2 as cv
import saveImg

def access_pixels(image):
    height, width, channels = image.shape
    for row in range(height):
        for list in range(width):
            for c in range(channels):
                pv = image[row, list, c]
                image[row, list, c] = 255 - pv
    return image
 
 
if __name__ == "__main__":
    src = cv.imread(sys.argv[1])
    # 运行函数
    newImage = access_pixels(src)
    saveImg.saveImage(sys.argv[1],newImage)