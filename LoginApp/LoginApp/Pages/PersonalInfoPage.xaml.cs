using LoginApp.Pages;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginUser.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PersonalInfoPage : ContentPage
	{
		public PersonalInfoPage ()
		{
			InitializeComponent ();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);

            var RegisterUserquery = db.Table<RegUserTable>();

            foreach (var item in RegisterUserquery)
            {
                RegUserTableData.Text = item.UserName;
            }
        }
    }
}