# YY.Screenshot
屏幕截图
# 使用方法
创建一个按钮,在按钮的单击时间下写:

            Screenshot screenshot = new Screenshot();
            Image image = this.screenshot.start(this, true, true);
            this.pictureBox1.Image = image;
