# YY.Screenshot
屏幕截图
![20210531195752193](https://user-images.githubusercontent.com/24205512/120226309-87328b00-c279-11eb-97d4-e63fca15e751.gif)

# 使用方法
放一个pictureBox1,一个按钮,在按钮的单击事件下写:

            this.pictureBox1.Image = new Screenshot().start(this, true, true);
           
