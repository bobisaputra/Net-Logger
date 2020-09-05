# Net-Logger
Logger for .Net

```C#
//Methods
log.Info(teks); // output without new line ,Font color white
log.InfoLn(teks);  // output with new line,Font color white

log.Warning(teks); // output without new line ,Font color orange
log.WarningLn(teks);  // output with new line,Font color orange

log.Error(teks); // output without new line ,Font color red
log.ErrorLn(teks);  // output with new line,Font color red
```
Examples :

```C#
using Logger;

namespace example{
public partial class Form1 : Form
    {
      public Form1()
        {
            InitializeComponent();
            log.onWrite += Log_onWrite;
        }
       private void Log_onWrite(string text,Color color)
        {
            // write on RichTexBox
            log.WriteOnEditor(RichTexBox1, text, color);
            
            // Write On Textbox
            log.WriteOnEditor(TexBox1, text, color);
        }   
      void showLog(){
            log.Info("hello");
            log.Error("waduh");
            log.Warning("mantull");
      }
      private void Form1_Load(object sender, EventArgs e)
        {
          showLog();
        }

  }
}
```
