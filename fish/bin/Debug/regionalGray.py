import cv2 as cv
import sys
import saveImg

if __name__ == '__main__':
	src=cv.imread(sys.argv[1])	 
	
	height,width,chanels = src.shape

	face=src[int(height*0.2):int(height*0.8),int(width*0.3):int(width*0.7)]
	 
	#将取出的区域改变为灰度图像
	gray=cv.cvtColor(face,cv.COLOR_BGR2GRAY)
	
	#将灰度图像变为RGB图像
	backface=cv.cvtColor(gray,cv.COLOR_GRAY2BGR)
	 
	#将取出并处理完的图像和原图合并起来
	src[int(height*0.2):int(height*0.8),int(width*0.3):int(width*0.7)]=backface
	saveImg.saveImage(sys.argv[1],src)