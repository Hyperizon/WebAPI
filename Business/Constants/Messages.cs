using Core.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants;

public static class Messages
{
    public static string ProductAdded = "Product successfully added.";
    public static string ProductDeleted = "Product successfully deleted.";
    public static string ProductUpdated = "Product successfully updated.";

    public static string CategoryAdded = "Category successfully added.";
    public static string CategoryDeleted = "Category successfully deleted.";
    public static string CategoryUpdated = "Category successfully updated.";

    public static string UserNotFound = "User Not Found";
    public static string PasswordError = "Incorrect Password";
    public static string SuccessfulLogin = "Successful Login";
    public static string UserAlreadyExists = "User already exists!";
    public static string UserRegistered = "User successfuly registered.";
}
