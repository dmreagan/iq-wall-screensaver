using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace IQ_Wall_Screensaver
{
  public partial class Form1 : Form
  {
    private AppSettingsReader configReader;
    private String url;
    private int refreshDelayInSeconds;
    private Timer refreshTimer;
  

    public Form1()
    {
      InitializeComponent();

      readConfigFile();
      setURL();
      initTimer();
      initEscListener();
    }

    private void initEscListener()
    {
      
    }    

        

        

        private void readConfigFile()
        {
            configReader = new AppSettingsReader();
            url = (String)configReader.GetValue("url", typeof(String));


            try
            {
              refreshDelayInSeconds = (int)configReader.GetValue("refreshDelayInSeconds", typeof(int));
            }
            catch (Exception)
            {
              MessageBox.Show("Error reading refresh delay from config file!\nUsing default delay of 10 minutes.");
              refreshDelayInSeconds = 600;

              //throw;
            }

            Console.WriteLine("url = " + url);
            Console.WriteLine("delay = " + refreshDelayInSeconds);
        }

        private void setURL()
        {
          try
          {
            webControl1.Source = new Uri(url);
          }
          catch (UriFormatException)
          {
            // config file error, so load default url as specified in designer
            MessageBox.Show("Error reading URL from config file!\nLoading default URL.");

            //throw;
          } 
        }

        private void initTimer()
        {
          refreshTimer = new Timer();
          refreshTimer.Interval = refreshDelayInSeconds * 1000;
          refreshTimer.Tick += new EventHandler(TimerEventHandler);
          refreshTimer.Start();
        }

        private void TimerEventHandler(object sender, EventArgs e)
        {
          refreshTimer.Stop();

          // refresh browser
          //webControl1.Reload(false);
          setURL();

          refreshTimer.Enabled = true;
        }
    }
}
