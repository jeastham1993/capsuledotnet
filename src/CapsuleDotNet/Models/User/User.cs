using System;

namespace CapsuleDotNet.Models
{
    public class User
    {
        private User(string username){
            this.Username = username;
        }

        public static User Create(string userName){
            if (string.IsNullOrEmpty(userName)){
                throw new ArgumentException("Username cannot be null or empty");
            }

            return new User(userName);
        }
        public long Id { get; set; }
        public string Name { get; private set; }
        public string Username { get; set; }
        public Party Party { get; set; }
        public string Timezone { get; set; }
        public string Locale { get; private set; }
        public string Currency { get; set; }
        public string EmailPreference { get; private set; }
        public string PreferredEmailFromAddress { get; set; }
        public string ClickToCallPreference { get; private set; }
        public bool? TaskReminder { get; set; }

        public void SetEmailPreference(EmailPreference preference){
            if (this.EmailPreference != nameof(preference)){
                this.EmailPreference = nameof(preference);
            }
        }

        public void SetLocale(Locale locale){
            if (this.Locale != nameof(locale)){
                this.Locale = nameof(locale);
            }
        }

        public void SetClickToCallPreference(ClickToCallPreference preference){
            if (this.ClickToCallPreference != nameof(preference)){
                this.ClickToCallPreference = nameof(preference);
            }
        }
    }
}