# Net-Logger
Logger .Net

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
            log.WriteOnEditor(RichTexBox1, text, color);
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
