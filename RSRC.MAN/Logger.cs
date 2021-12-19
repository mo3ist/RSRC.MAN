using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace RSRC.MAN
{
    class Logger
    {

        public static string LogFilePath = @".\log.rtf";

        // In-memory logging
        public static string Log = null; 

        static Logger()
        {

        }

        // https://stackoverflow.com/a/61798112
        private static string ConvertToRtf(string text)
        {
            // using default template from wiki
            StringBuilder sb = new StringBuilder(@"{\rtf1\ansi\ansicpg1250\deff0{\fonttbl\f0\fswiss Helvetica;}\f0\pard ");
            foreach (char character in text)
            {
                if (character <= 0x7f)
                {
                    // escaping rtf characters
                    switch (character)
                    {
                        case '\\':
                        case '{':
                        case '}':
                            sb.Append('\\');
                            break;
                        case '\r':
                            sb.Append("\\par");
                            break;
                    }

                    sb.Append(character);
                }
                // converting special characters
                else
                {
                    sb.Append("\\u" + Convert.ToUInt32(character) + "?");
                }
            }
            sb.Append("}");
            return sb.ToString();
        }

        private static void Write(string message, Color color, Font font)
        {
            using (RichTextBox RTB = new RichTextBox())
            {
                DateTime timestamp = DateTime.Now;

                string new_message = String.Format("[{0}]: {1}", timestamp, message);

                // Formatting trick (Cut & Paste)
                using (RichTextBox temp_rtb = new RichTextBox())
                {

                    temp_rtb.AppendText(new_message);

                    temp_rtb.SelectAll();
                    temp_rtb.SelectionColor = color;

                    temp_rtb.SelectionFont = font;

                    temp_rtb.Cut();
                }

                if (Log != null)
                {
                    RTB.Rtf = Log;
                    RTB.AppendText(Environment.NewLine);
                }

                RTB.Paste();
                Log = RTB.Rtf;
            }
        }

        public static void Debug(string message)
        {
            Write("[DEBUG] " + message, Color.DarkGreen, new Font("Verdana", 10, FontStyle.Regular));
        }

        public static void Info(string message)
        {
            Write("[INFO] " + message, Color.DarkBlue, new Font("Verdana", 10, FontStyle.Regular));
        }

        public static void Warning(string message)
        {
            Write("[WARNING] " + message, Color.DarkGoldenrod, new Font("Verdana", 10, FontStyle.Regular));
        }

        public static void Error(string message)
        {
            Write("[ERROR] " + message, Color.DarkOrange, new Font("Verdana", 10, FontStyle.Regular));
        }

        public static void Fatal(string message)
        {
            Write("[FATAL] " + message, Color.DarkRed, new Font("Verdana", 10, FontStyle.Regular));
        }

        public static string GetLog()
        {
            try
            {
                return Log;
            }
            catch
            {
                return null;
            }

        }
    }
}
