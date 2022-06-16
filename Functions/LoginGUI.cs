using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.UserModel;
using MongoDB.Driver;

namespace HealthcareSystem.Functions
{
    partial class LoginGUI : Form
    {

        public Login login;
        public User loggedUser;
        
        public LoginGUI(IMongoDatabase db)
        {

            this.login = new Login(db);
            InitializeComponent();


            
            
        }

        private void LoginGUI_Load(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            int loggedStatus = login.Validate(emailBox.Text,passwordBox.Text);
            if (loggedStatus == 0)
            {
                statusLabel.Text = "Email/Password combination do not exist!";
            }
            else if (loggedStatus == 2) 
            {
                statusLabel.Text = "The user has been blocked";
            }           
            else if(loggedStatus == 1){ 
                this.loggedUser = login.userService.CheckCredentials(emailBox.Text,passwordBox.Text);
                
                this.Hide();
                login.SuccessfulLogin(loggedUser);

            }
            else if(loggedStatus==3)
            {
                this.loggedUser = login.doctorRepository.checkCredentials(emailBox.Text, passwordBox.Text);
                this.Hide();
                login.SuccessfulLogin(loggedUser);
                
            }
            statusLabel.Visible = true;
            

        }
        

        private void emailBox_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
