
using System.Text.RegularExpressions;

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
            Regex regexForAlphaValue = new Regex(@"[\d]");
            Regex regexForPhoneNumber = new Regex(@"^-?[0-9][0-9,\.]+$");

            Console.WriteLine("\n================+-+-+-+-+-+WELCOME TO DELIVERION+-+-+-+-+-+================\n\n");
            Console.WriteLine("  Shipper Registration Form\n\n");
            Console.WriteLine("  Enter Shipper Personal Details:\n\n");

            Console.Write("Enter First Name:");
        gotoFirstName:
            form.FirstName = Console.ReadLine();  // You need to enter fname second time only if our validations throws error for input..!

            if (string.IsNullOrEmpty(form.FirstName) || string.IsNullOrWhiteSpace(form.FirstName))
            {
                Console.Write("\nFirst name should be not null..!\n\nEnter First Name:");
                goto gotoFirstName;
            }
            if (regexForAlphaValue.IsMatch(form.FirstName))
            {
                Console.Write("\nFirst Name letters should be alphabets...!\n\nEnter First Name:");
                goto gotoFirstName;
            }
            Console.Write("\n\nEnter Middle Name(Optional):");
            form.MiddleName = Console.ReadLine();

            Console.Write("\n\nEnter the Last Name:");
        gotoLastName:
            form.LastName = Console.ReadLine();
            if (string.IsNullOrEmpty(form.LastName) || string.IsNullOrWhiteSpace(form.LastName))
            {
                Console.Write("\nLast name should not be null..!\n\nEnter the Last Name:");
                goto gotoLastName;
            }
            else if (regexForAlphaValue.IsMatch(form.LastName))
            {
                Console.Write("\nLast Name letters should be alphabets...!\n\nEnter the Last Name:");
                goto gotoLastName;
            }
            Console.Write("\n\nEnter the Email ID:");
        gotoEmailId:
            form.Email = Console.ReadLine().ToLower();

            if (string.IsNullOrEmpty(form.Email) || string.IsNullOrWhiteSpace(form.Email))
            {
                Console.Write("\nThe Email Id should not be null..!\n\nEnter the Email Id:");
                goto gotoEmailId;
            }
            else if (!(form.Email.EndsWith("@outlook.com") || form.Email.EndsWith("@gmail.com") || form.Email.EndsWith("@incubxperts.com")))
            {
                Console.Write("\nEnter the Correct Email Id Domain...!\nEmail Id Domains(gmail,outlook,incubxperts)\n\nEnter Email Id:");
                goto gotoEmailId;
            }           

            Console.Write("\n\nEnter the Age:");

        AgeFieldChecker:
            string age = Console.ReadLine();
            if (!(regexForAlphaValue.IsMatch(age)))
            {
                Console.Write("\nAll the values should be numeric..!\n\nEnter the Age:");
                goto AgeFieldChecker;
            }
            else
            {
                form.Age = Convert.ToInt32(age);
                if (!(form.Age >= 18) || (form.Age >= 120))
                {
                    Console.WriteLine("\nAccording to Shipper Account Age Limits. You are not eligible to become Shipper...!\n");
                    Console.WriteLine("         Thank You For Using Our Service             \n\n");
                    Environment.Exit(0);
                }
            }
            if (string.IsNullOrWhiteSpace(Convert.ToString(age)) || string.IsNullOrEmpty(Convert.ToString(age)))
            {
                Console.Write("\nInvalid Age should not be null..!\n\nEnter the Age :");
                goto AgeFieldChecker;
            }

            Console.Write("\n\nEnter the Phone Number:");

        phoneNumberAdder:
            string phoneNumbercheker = Console.ReadLine();
            if (!(regexForPhoneNumber.IsMatch(phoneNumbercheker)))
            {
                Console.Write("\nAll the values should be numeric..!\n\nEnter the Phone Number:");
                goto phoneNumberAdder;
            }
            else
            {
                form.PhoneNumber = Convert.ToInt64(phoneNumbercheker);
            }
            if (string.IsNullOrWhiteSpace(Convert.ToString(form.PhoneNumber)) || string.IsNullOrEmpty(Convert.ToString(form.PhoneNumber)))
            {
                Console.Write("\nInvalid Phone Number should not be null..!\n\nEnter the Phone Number:");
                goto phoneNumberAdder;
            }
            if ((Convert.ToString(form.PhoneNumber)).Length == 12)
            {
                Console.Write("\nDon't add the country code in phone number..!\n\nEnter the Phone Number:");
                goto phoneNumberAdder;
            }
            else if ((Convert.ToString(form.PhoneNumber)).Length != 10)
            {
                Console.Write("\nInvalid Phone Number Entered..!\n\nEnter the Phone Number:");
                goto phoneNumberAdder;
            }

            Console.WriteLine("\n\n1. Permanent Account Number (PAN)\n2. Aadhar Card\n3. Driving License");
            Console.Write("\n\nEnter Government Id Name:");
        governmentIdNameChecker:
            form.GovernmentIdName = Console.ReadLine();

            if (string.IsNullOrEmpty(form.GovernmentIdName) || string.IsNullOrWhiteSpace(form.GovernmentIdName))
            {
                Console.Write("\nChoose Correct Government Id Name. Field should not be null..!\n\nEnter Choose the option number assigned Governmemnt Id Name (1/2/3):");
                goto governmentIdNameChecker;
            }
            else if (!(regexForAlphaValue.IsMatch(form.GovernmentIdName)))
            {
                Console.Write("\nGovernment Id Name Choice should be numeric...!\n\nEnter Choose the option number assigned Governmemnt Id Name (1/2/3):");
                goto governmentIdNameChecker;
            }

            if (form.GovernmentIdName == "1")
            {
                Console.Write("\nEnter the Permanent Account Number:");
                form.SetGovernmentIdName = "Permanent Account Number (PAN)";
            }
            else if(form.GovernmentIdName == "2")
            {
                Console.Write("\nEnter the Aadhar Number:");
                form.SetGovernmentIdName = "Aadhar Card";
            }
            else if(form.GovernmentIdName == "3")
            {
                Console.Write("\nEnter the Driving License:");
                form.SetGovernmentIdName = "Driving License";
            }
        governmentIdChecker:
            form.GovernmentId = Console.ReadLine();
            if (string.IsNullOrEmpty(form.GovernmentId) || string.IsNullOrWhiteSpace(form.GovernmentId))
            {
                Console.Write("\nGovernment Id should not be null..!\n\nEnter the Government Id Number:");
                goto governmentIdChecker;
            }
            if (form.GovernmentIdName == "2")
            {
                if (!(form.GovernmentId.Length == 12))
                {
                    Console.Write("\nInvalid Government Id...!\n\nEnter the Government Id Number:");
                    goto governmentIdChecker;
                }
                if(!(regexForPhoneNumber.IsMatch(form.GovernmentId)))
                {
                    Console.WriteLine("Aadhar Card Number should be numeric...!\n\nEnter the Aadhar Card Number:");
                    goto governmentIdChecker;
                }
            }
            if (form.GovernmentIdName == "1")
            {
                if (!(form.GovernmentId.Length == 10))
                {
                    Console.Write("\nInvalid Government Id...!\n\nEnter the Government Id Number:");
                    goto governmentIdChecker;
                }
            }
            if (form.GovernmentIdName == "3")
            {
                if (!(form.GovernmentId.Length == 15))
                {
                    Console.Write("\nInvalid Government Id...!\n\nEnter the Government Id Number:");
                    goto governmentIdChecker;
                }
            }

        // Address Entry & Validation
            Console.Write("Enter Your Full Permanent Address (As Per Govt Id Proof):");
        addressChecker:
            form.Address = Console.ReadLine().ToLower();
            if (string.IsNullOrWhiteSpace(form.Address) || string.IsNullOrEmpty(form.Address))
            {
                Console.Write("\nInvalid Full Address. Field should not be null..!\n\nEnter Your Permanent Address (As Per Govt Id Proof):");
                goto addressChecker;
            }
            else if (form.Address.Length <= 20)
            {
                Console.Write("\n\nInvalid Address Length...!\nEnter Your Full Permanent Address (As Per Govt Id Proof):");
                goto addressChecker;
            }
            Console.Write("\n\n===================+-+-+-+-+-+- Deliverion Shipper Account Summary +-+-+-+-+-+-===================\n\n");
            Console.WriteLine("      Shipper Personal Details:     ");
            Console.Write("\n\nFull Name: {0} {1} {2} \n\n",form.FirstName, form.MiddleName, form.LastName);
            Console.WriteLine("Government Id Name: {0}\n\nGovernment Id: {1}\n", form.SetGovernmentIdName, form.GovernmentId);
            Console.WriteLine("Age: {0} \n", form.Age);
            Console.WriteLine("Email Id: {0} \n", form.Email);
            Console.WriteLine("Phone Number: {0} \n", form.PhoneNumber);
            Console.WriteLine("Permanent Address Details: {0}\n\n",form.Address);
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
        private string _setgovernmentidname;
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
        public string SetGovernmentIdName
        {
            get { return _setgovernmentidname; }
            set { _setgovernmentidname = value; }
        }
    }
}
