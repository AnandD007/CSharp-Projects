
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DeliveryKycConsoleApp
{
    internal class DeliveryKycApp
    {
        static void Main(string[] args)
        {
            try
            {
                PersonalInformation.ShipperPersonalDetails();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
    class PersonalInformation
    {
        public static void ShipperPersonalDetails()
        {
            KYCForm form = new KYCForm();
            form.FirstName = "";
            form.LastName = "";
            form.Email = "";
            form.Age = 0;
            form.PhoneNumber = 0;
            form.Address = "";
            form.MiddleName = "";
            form.GovernmentId = "";
            string firstName = form.FirstName;
            string lastName = form.LastName;
            string emailId = form.Email;
            string middleName = form.MiddleName;
            int ageRange = form.Age;
            long phoneNumber = form.PhoneNumber;
            string address = form.Address;
            string governmentId = form.GovernmentId;
            string governmentIdName = form.GovernmentIdName;
            Regex regexForAlphaValue = new Regex(@"[\d]");
            Regex regexForPhoneNumber = new Regex(@"[\d]$");

            Console.WriteLine("\n================+-+-+-+-+-+WELCOME TO DELIVERION+-+-+-+-+-+================\n\n");
            // new user entry
            Console.WriteLine("                       Enter Shipper Personal Details:\n");

            Console.Write("\nEnter First Name:");
        gotoFirstName:
            firstName = Console.ReadLine();  // You need to enter fname second time only if our validations throws error for input..!
                                             // Content "" validation checking
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrWhiteSpace(firstName))
            {
                Console.Write("\nFirst name should be not null..!\n\nEnter First Name:");
                goto gotoFirstName;
            }
            if (regexForAlphaValue.IsMatch(firstName))
            {
                Console.Write("\nFirst Name letters should be alphabets...!\n\nEnter First Name:");
                goto gotoFirstName;
            }
            Console.Write("\nEnter Middle Name(Optional):");
            middleName = Console.ReadLine();

            Console.Write("\n\nEnter Last Name:");
        gotoLastName:
            lastName = Console.ReadLine();
            if (string.IsNullOrEmpty(lastName) || string.IsNullOrWhiteSpace(lastName))
            {
                Console.Write("\nLast name should not be null..!\n\nEnter List Name:");
                goto gotoLastName;
            }
            else if (regexForAlphaValue.IsMatch(lastName))
            {
                Console.Write("\nLast Name letters should be alphabets...!\n\nEnter First Name:");
                goto gotoLastName;
            }

            Console.Write("\n\nEnter Email ID:");
        gotoEmailId:
            emailId = Console.ReadLine().ToLower();

            Console.WriteLine((emailId).Length);

            if (string.IsNullOrEmpty(emailId) || string.IsNullOrWhiteSpace(emailId))
            {
                Console.Write("\nEmail Id  should not be null..!\n\nEnter Email Id:");
                goto gotoEmailId;
            }
            else if (!(emailId.EndsWith("@outlook.com") || emailId.EndsWith("@gmail.com") || emailId.EndsWith("@incubxperts.com")))
            {
                Console.Write("\nEnter Correct Email Id Domain...!\nEmail Id Domains(gmail,outlook,incubxperts)\n\nEnter Email Id:");
                goto gotoEmailId;
            }
            // ---------------------------------------------------------------                

            Console.Write("\n\nEnter the Age:");

        AgeFieldChecker:
            string age = Console.ReadLine();
            if (!(regexForPhoneNumber.IsMatch(age)))
            {
                Console.Write("\nAll the values should be numeric..!\n\nEnter the Age:");
                goto AgeFieldChecker;
            }
            else
            {
                int AgeRange = Convert.ToInt32(age);
            }
            if (string.IsNullOrWhiteSpace(Convert.ToString(age)) || string.IsNullOrEmpty(Convert.ToString(age)))
            {
                Console.Write("\nInvalid Age should not be null..!\n\nEnter the Age :");
                goto AgeFieldChecker;
            }

            Console.Write("\n\nEnter Phone Number:");

        phoneNumberAdder:
            string phoneNumbercheker = Console.ReadLine();
            if (!(regexForPhoneNumber.IsMatch(phoneNumbercheker)))
            {
                Console.Write("\nAll the values should be numeric..!\n\nEnter Phone Number:");
                goto phoneNumberAdder;
            }
            else
            {
                phoneNumber = Convert.ToInt64(phoneNumbercheker);
            }
            if (string.IsNullOrWhiteSpace(Convert.ToString(phoneNumber)) || string.IsNullOrEmpty(Convert.ToString(phoneNumber)))
            {
                Console.Write("\nInvalid Phone Number should not be null..!\n\nEnter Phone Number:");
                goto phoneNumberAdder;
            }
            if ((Convert.ToString(phoneNumber)).Length == 12)
            {
                Console.Write("\nDon't add the country code in phone number..!\n\nEnter Phone Number:");
                goto phoneNumberAdder;
            }
            else if ((Convert.ToString(phoneNumber)).Length != 10)
            {
                Console.Write("\nInvalid Phone Number Entered..!\n\nEnter Phone Number:");
                goto phoneNumberAdder;
            }

            Console.WriteLine("\n\n1. Permanent Account Number (PAN)\n2. Aadhar Card\n3. Driving License");
            Console.Write("\n\nEnter Government Id Name:");
            int choice = 10;
        governmentIdNameChecker:
            governmentIdName = Console.ReadLine();

            if (string.IsNullOrEmpty(governmentIdName) || string.IsNullOrWhiteSpace(governmentIdName))
            {
                Console.Write("\nChoose Correct Government Id Name. Field should not be null..!\n\nEnter Choose the option number assigned Governmemnt Id Name (1/2/3):");
                goto governmentIdNameChecker;
            }
            else if (!(regexForPhoneNumber.IsMatch(governmentIdName)))
            {
                Console.Write("\nGovernment Id Name Choice should be numeric...!\n\nEnter Choose the option number assigned Governmemnt Id Name (1/2/3):");
                goto governmentIdNameChecker;
            }
            Console.Write("\n\nEnter the Government Id Number:");
        governmentIdChecker:
            governmentId = Console.ReadLine();
            if (string.IsNullOrEmpty(lastName) || string.IsNullOrWhiteSpace(lastName))
            {
                Console.Write("\nLast name should not be null..!\n\nEnter the Government Id Number:");
                goto governmentIdChecker;
            }
            if (governmentIdName == "2")
            {
                if (!(governmentId.Length == 12))
                {
                    Console.Write("\nInvalid Government Id...!\n\nEnter the Government Id Number:");
                    goto governmentIdChecker;
                }
            }
            if (governmentIdName == "1")
            {
                if (!(governmentId.Length == 10))
                {
                    Console.Write("\nInvalid Government Id...!\n\nEnter the Government Id Number:");
                    goto governmentIdChecker;
                }
            }
            if (governmentIdName == "3")
            {
                if (!(governmentId.Length == 15))
                {
                    Console.Write("\nInvalid Government Id...!\n\nEnter the Government Id Number:");
                    goto governmentIdChecker;
                }
            }

        // Address Entry & Validation
            Console.Write("\n\nEnter Your Permanent Address (As Per Govt Id Proof):");
            
        addressChecker:
            address = Console.ReadLine().ToLower();
            if (string.IsNullOrWhiteSpace(address) || string.IsNullOrEmpty(address))
            {
                Console.Write("\nInvalid Permanent Address. Field should not be null..!\n\nEnter Your Permanent Address (As Per Govt Id Proof):");
                goto addressChecker;
            }
            else if (address.Length <= 20)
            {
                Console.Write("\n\nEnter Your Full Permanent Address (As Per Govt Id Proof):");
                goto addressChecker;
            }
            Console.Write("\n\n===================+-+-+-+-+-+- Deliverion Shipper Account Summary +-+-+-+-+-+-===================\n\n");
            Console.WriteLine("      Shipper Personal Details:     ");
            Console.Write("\n\nFull Name: {0}", string.Concat(firstName, middleName, lastName));
            Console.WriteLine("Government Id Name: {0} :  Id: {1}", governmentIdName, governmentId);
            Console.WriteLine("Age: {0}", ageRange);
            Console.WriteLine("Email Id: {0}", emailId);
            Console.WriteLine("Phone Number: {0}", phoneNumber);
            Console.WriteLine("\nPermanent Address Details: {0}\n\n",address);
            Console.WriteLine("         Thank You For Using Our Service             \n\n");
        }
    }
    class KYCForm
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private int _age;
        private long _phoneNumber;
        private string _address;
        private string _middleName;
        private string _governmentid;
        private string _governmentidname;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public string MiddleName
        {
            get { return _middleName; }
            set { _middleName = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public long PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public string GovernmentId
        {
            get { return _governmentid; }
            set { _governmentid = value; }
        }
        public string GovernmentIdName
        {
            get { return _governmentidname; }
            set { _governmentidname = value; }
        }

    }
}