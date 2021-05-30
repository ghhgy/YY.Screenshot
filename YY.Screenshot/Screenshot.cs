using System.Windows.Forms;

namespace YY.Screenshot
{
    public class Screenshot
    {
        public Screenshot()
        {
           
        }
          static Screenshot()
        {

            screenshotForm = new ScreenshotForm();
        }
        public static YY.Screenshot.ScreenshotForm screenshotForm;
        /// <summary>
        /// 开始截屏
        /// </summary>
        /// <param name="mainForm">直接填写this</param>
        /// <param name="isHideForm">截图时是否隐藏窗体</param>
        /// <param name="isCopyToClipboard">是否复制到剪贴板</param>
        public static System.Drawing.Image start(Form mainForm, bool isHideForm, bool isCopyToClipboard = true)
        {
            if (screenshotForm == null) { screenshotForm = new ScreenshotForm(); }
      
            if (isHideForm) { mainForm.Opacity = 0; }
            if (isCopyToClipboard) { screenshotForm.isCopyToClipboard = true; }
            if (screenshotForm.ShowDialog() == DialogResult.Cancel)
            {
                mainForm.Opacity = 100;
            }
            return screenshotForm.img2;
        }
        /// <summary>
        /// 开始截屏
        /// </summary>
        public System.Drawing.Image start()
        {
            if (screenshotForm == null) { screenshotForm = new ScreenshotForm(); }
             screenshotForm.isCopyToClipboard = true;
             screenshotForm.ShowDialog();
            return screenshotForm.img2;
        }
    }
}
