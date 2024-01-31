using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaProjet.Model;
public class User
{
 
     
    private List<UserInfo> userList;
    //List<User> userList = new List<User>();

    public User() 
    {
        userList = new List<UserInfo>();
        userList.Add(new UserInfo { Username = "kofi", Email = "kofi@gmail.com", Password = "123456" });
        userList.Add(new UserInfo { Username = "ama", Email = "ama@gmail.com", Password = "654321" });
        userList.Add(new UserInfo { Username = "dav", Email = "davidouthe2@gmail.com", Password = "12345678" });
    }

    public int log(string email, string password)
    {
       
        int a = 0;
        foreach (UserInfo user in userList)
        {
            if (email == user.Email & password == user.Password)
            {
                Global.CurrentUser = user;
                return a = 1;
            }
            else if ((email == user.Email & password != user.Password))
            {
               return a = 2;
            }
            else
            {
               return a = 3;
            }

        }
        return 4;
    }

    public int sign(string email,string username, string password, string passwordok)
    {
        int a = 0;
        foreach (UserInfo user in userList)
        {
            if (email == user.Email)
            {

                return a = 1;
            }
        }
        if (password.Length <8)
        {
            return a = 2;
        }
        else if(password != passwordok)
        {
            return a = 3;
        }
        UserInfo user1 = new UserInfo(username, email, password);
        userList.Add(user1);
        Global.CurrentUser = user1;
        return 4;
    }

    public static class Global
    {
        public static UserInfo CurrentUser { get; set; }
    }
    
}

public class UserInfo
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public UserInfo() { }
    public UserInfo(string username, string email, string password)
    {
        Username = username;
        Email = email;
        Password = password;
    }
} 
