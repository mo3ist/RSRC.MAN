using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSRC.MAN
{
    // https://stackoverflow.com/a/60445431
    public class RichFilterableTextBox : RichTextBox
    {
        private Timer timer;
        private string OriginalRTF = null;
        private TextBox _filterReference;
        private int _interval = 100;

        public TextBox FilterReference
        {
            get => _filterReference;
            set
            {
                //if we had already a filter reference
                if (_filterReference != null)
                {
                    //we should remove the event
                    _filterReference.TextChanged -= FilterChanged;
                }

                _filterReference = value;

                //if our new filter reference is not null we need to register our event
                if (_filterReference != null)
                    _filterReference.TextChanged += FilterChanged;
            }
        }

        /// <summary>
        /// After the filter has been entered into the FilerReference TextBox 
        /// this will auto apply the filter once the interval has been passed.
        /// </summary>
        public int Interval
        {
            get => _interval;
            set
            {
                _interval = value;
                timer.Interval = Interval;
            }
        }
        public RichFilterableTextBox()
        {
            timer = new Timer();
            timer.Interval = Interval;
            timer.Tick += TimerIntervalTrigger;
        }

        public void SetFilterControl(TextBox textbox)
        {
            this.FilterReference = textbox;
        }

        public void ApplyFilter(string searchstring)
        {
            int startIndex = 0;
            int offset = 0;

            //check each line
            foreach (var line in this.Lines)
            {
                offset = 0;
                SelectionStart = startIndex + offset;
                SelectionLength = line.Length + 1;

                //if our line contains our search string/filter
                if (line.Contains(searchstring))
                {
                    //we apply an offset based on the line length
                    offset = line.Length;
                }
                else
                {
                    //otherwise delete the line
                    SelectedText = "";
                }

                //move the start index forward based on the current selected text
                startIndex += this.SelectedText.Length;
            }
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            //take snapshot of original
            if (OriginalRTF == null)
            {
                OriginalRTF = this.Rtf;
            }
            else
            {
                //restore original
                Rtf = OriginalRTF;
                OriginalRTF = null;
            }

            timer.Stop();
            timer.Start();
        }
        private void TimerIntervalTrigger(object sender, EventArgs e)
        {
            //stop the timer to avoid multiple triggers
            timer.Stop();

            //apply the filter
            ApplyFilter(FilterReference.Text);
        }
        protected override void Dispose(bool disposing)
        {
            timer.Stop();
            timer.Dispose();

            base.Dispose(disposing);
        }
    }

}
