using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Globalization; // Provides access to Globalization settings APIs
using Windows.System.UserProfile; // Provides access to user preference setting APIs

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Homework1BaseCode
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            // My code 
            //IReadOnlyList<string> userLanguages = GlobalizationPreferences.Languages;
            var userLanguages = GlobalizationPreferences.Languages[0];
            var shortDateFormatter = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("shortdate");
            var shortTimeFormatter = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("shorttime");
            var userCurrency = GlobalizationPreferences.Currencies[0];
            var userRegion = GlobalizationPreferences.HomeGeographicRegion;
            var userCalendar = GlobalizationPreferences.Calendars[0];
            var userWeekStart = GlobalizationPreferences.WeekStartsOn;
            var userClock = GlobalizationPreferences.Clocks[0];
            var langDetails = GlobalizationPreferences.Languages[1];
            var dateTimeToFormat = DateTime.Now;

            string results = $"Short Date: {shortDateFormatter.Format(dateTimeToFormat)}\n" +
                          $"Short Time: {shortTimeFormatter.Format(dateTimeToFormat)}";

            // Get the user's geographic region and its display name.
            var displayGeo = new GeographicRegion().DisplayName;

            // Loading resources from Resources.resw
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            var lang = loader.GetString("chosen_lang");
            var home = loader.GetString("home_region");
            var calendar = loader.GetString("calendar_setting");
            var clock = loader.GetString("clock_setting");
            var week = loader.GetString("week_start");
            var lang_d = loader.GetString("lang_details");
            var geo = loader.GetString("geo_details");

            //Globalization Preferences
            chosen_lang.Text += $"{lang}: {userLanguages}\n";
            home_region.Text += $"{home}: {userRegion}\n";
            calendar_setting.Text += $"{calendar}: {userCalendar}\n";
            clock_setting.Text += $"{clock}: {userClock}\n";
            week_start.Text += $"{week}: {userWeekStart}\n";

            //Language Specifics
            lang_details.Text = $"{lang_d}: {langDetails}\n";

            //Geo Region Specifics
            geo_details.Text = $"{geo}: {displayGeo}\n" +
                $"User currency: {userCurrency}\n" +
                results;
        }
    }
}