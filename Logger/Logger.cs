using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
namespace Logger
{
    public static class log
    {
        static List<string> _cache = new List<string>();
        static List<Color> _color = new List<Color>();
        private static  Color defaultColor = Color.White;
      
        public static event _onWrite onWrite;
        public delegate void _onWrite(string text, Color color);

        public static void WriteOnEditor<T>(T editor, string text, Color color)
        {
            var properties = editor.GetType().GetProperties();
            foreach (PropertyInfo propinfo in properties)
            {
                if (propinfo.Name == "SelectionColor")
                {
                    propinfo.SetValue(editor, color);
                }
            }
            var methods = editor.GetType().GetMethods();
            foreach (MethodInfo minfo in methods)
            {
                switch (minfo.Name)
                {
                    case "SuspendLayout":
                        if (minfo.GetParameters().Length == 0)
                        {
                            minfo.Invoke(editor, null);
                        }
                        break;
                    case "AppendText":
                        if (minfo.GetParameters().Length == 1)
                        {
                            minfo.Invoke(editor, new object[] { text });
                        }

                        break;
                    case "ScrollToCaret":
                        if (minfo.GetParameters().Length == 0)
                        {
                            minfo.Invoke(editor, null);
                        }
                        break;
                    case "ResumeLayout":
                        if (minfo.GetParameters().Length == 0)
                        {
                            minfo.Invoke(editor, null);
                        }
                        break;
                }
            }
        }
  
        public static void Write(string text,Color ? color=null)
        {
            onWrite?.Invoke($"{text}", color ?? Color.White);
        }
        public static void WriteLn(string text, Color? color = null)
        {
            onWrite?.Invoke($"{text}{Environment.NewLine}", color ?? Color.White);
        }
        public static void InfoLn(string text)
        {
            onWrite?.Invoke($"Info [{DateTime.Now}] : {text}{Environment.NewLine}", Color.White);
        }
        public static void Info(string text)
        {
            onWrite?.Invoke($"Info [{DateTime.Now}] : {text} ", Color.White);
        }
        public static void Success(string text)
        {
            onWrite?.Invoke($"Success [{DateTime.Now}] : {text}", Color.YellowGreen);
        }
        public static void SuccessLn(string text)
        {
            onWrite?.Invoke($"Success [{DateTime.Now}] : {text}{Environment.NewLine}", Color.YellowGreen);
        }
        public static void Error(string text)
        {
            onWrite?.Invoke($"Error [{DateTime.Now}] : {text}", Color.Red);
        }
        public static void ErrorLn(string text)
        {
            onWrite?.Invoke($"Error [{DateTime.Now}] : {text}{Environment.NewLine}", Color.Red);
        }
        public static void Warning(string text)
        {
            onWrite?.Invoke($"Warning [{DateTime.Now}] : {text}", Color.Orange);
        }
        public static void WarningLn(string text)
        {
            onWrite?.Invoke($"Warning [{DateTime.Now}] : {text}{Environment.NewLine}", Color.Orange);
        }

    }
}
