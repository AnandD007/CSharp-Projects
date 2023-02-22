/*

// Banking Registration System:
using System;
using System.Security.Cryptography;

namespace Assignment_2_Bank_Registration_System
{
    class BankAppVersion1
    {

        static void Main(string args)
        {
            string firstName = null;
            string lastName = "";
            string middleName = "";
            string emailId = "";
            long phoneNumber = 0;
            string gender = "";
            string panNumber = "";
            string dateOfBirth = "";
            string maritalStatus = "";// {"single","married","divorced","widowed"}
            string permanentAddress = "";
            string communicationAddress = "";
            long creditAmountLimit = 0;
            bool m = true;
            int i = 0;
            while (m == true)
            {
                Console.WriteLine("\n================++++++WELCOME TO BANK OF PUNE++++++================\n\n");
                // new user entry
                Console.WriteLine("Create Your Personal Details:\n");
                Console.Write(i);
                Console.Write("\nEnter Your First Name:");
            gotoFirstName:
                firstName = Console.ReadLine();  // You need to enter fname second time only if our validations throws error for your input..!
                // Content "" validation checking
                if (firstName == "" || firstName == " " || firstName == "")
                {
                    Console.Write("\nFirst name should be not null..!\n\nEnter Your First Name:");
                    goto gotoFirstName;
                }
                else if (firstName.Contains("1") || firstName.Contains("2") || firstName.Contains("3") || firstName.Contains("4") || firstName.Contains("5") || firstName.Contains("6") || firstName.Contains("7") || firstName.Contains("8") || firstName.Contains("9") || firstName.Contains("0"))
                {
                    Console.Write("\nFirst Name letters should be alphabets...!\n\nEnter Your First Name:");
                    goto gotoFirstName;
                }
                Console.Write("\nEnter Your Middle Name:");
                middleName = Console.ReadLine();

                Console.Write("\n\nEnter Your Last Name:");
            gotoLastName:
                lastName = Console.ReadLine();
                if (lastName == "" || lastName == " " || lastName == "")
                {
                    Console.Write("\nLast name should not be null..!\n\nEnter Your List Name:");
                    goto gotoLastName;
                }
                else if (firstName.Contains("1") || firstName.Contains("2") || firstName.Contains("3") || firstName.Contains("4") || firstName.Contains("5") || firstName.Contains("6") || firstName.Contains("7") || firstName.Contains("8") || firstName.Contains("9") || firstName.Contains("0"))
                {
                    Console.Write("\nFirst Name letters should be alphabets...!\n\nEnter Your First Name:");
                    goto gotoLastName;
                }
                Console.Write("\n\nEnter Your Email ID:");
            gotoEmailId:
                emailId = Console.ReadLine().ToLower();
                // int pos1 = emailId.IndexOf("@");
                Console.WriteLine((emailId).Length);
                // Console.WriteLine(pos1);
                if (emailId == "" || emailId == "" || emailId == " ")
                {
                    Console.Write("\nEmail Id  should not be null..!\n\nEnter Your Email Id:");
                    goto gotoEmailId;
                }
                else if (!(emailId.EndsWith("@outlook.com") || emailId.EndsWith("@gmail.com") || emailId.EndsWith("@incubxperts.com")))
                {
                    Console.Write("\nEnter Correct Email Id Domain...!\nEmail Id Domains(gmail,outlook,incubxperts)\n\nEnter Your Email Id:");
                    goto gotoEmailId;
                }
                // ---------------------------------------------------------------                
                Console.Write("\n\nEnter Your Phone Number:");

            phno_adder:
                string tem1 = Convert.ToString(Console.ReadLine());

                if (!(tem1.Contains("1") || tem1.Contains("2") || tem1.Contains("3") || tem1.Contains("4") || tem1.Contains("5") || tem1.Contains("6") || tem1.Contains("7") || tem1.Contains("8") || tem1.Contains("9") || tem1.Contains("0")))
                {
                    Console.Write("\nAll the values should be numeric..!\n\nEnter Your Phone Number:");
                    goto phno_adder;
                }
                else
                {
                    phoneNumber = Convert.ToInt64(tem1);
                }
                if (phoneNumber == null || phoneNumber == 0)
                {
                    Console.Write("\nInvalid Phone Number should not be null..!\n\nEnter Your Phone Number:");
                    goto phno_adder;
                }
                if ((Convert.ToString(phoneNumber)).Length == 12)
                {
                    Console.Write("\nDon't add the country code in phone number..!\n\nEnter Your Phone Number:");
                    goto phno_adder;
                }
                else if ((Convert.ToString(phoneNumber)).Length != 10)
                {
                    Console.Write("\nInvalid Phone Number Entered..!\n\nEnter Your Phone Number:");
                    goto phno_adder;
                }
                //-------------------------------------------------------------------
                // PAN Details:
                Console.Write("\n\nEnter Your Permanent Account Number(PAN):");

            pan_adder:
                panNumber = Console.ReadLine();
                if (panNumber == null || panNumber == "" || panNumber == " ")
                {
                    Console.Write("\nInvalid PAN Card. Field should not be null..!\n\nEnter Your Permanent Account Number(PAN):");
                    goto pan_adder;
                }
                else if (panNumber.Length != 10)
                {
                    Console.Write("\nInvalid PAN Card Number Entered..!\n\nEnter Your Permanent Account Number(PAN):");
                    goto pan_adder;
                }
                // --------------------------------------------------------------------------
                Console.Write("\n\nEnter Your Gender (male/female/others):");

            gender_adder:
                gender = Console.ReadLine().ToLower();
                if (gender == null || gender == "" || gender == " ")
                {
                    Console.Write("\nInvalid Gender Status. Field should not be null..!\n\nEnter Your Gender (Male/Female/Others):");
                    goto gender_adder;
                }
                else if (!(gender == "male" || gender == "female" || gender == "others"))
                {
                    Console.Write("\nInvalid Gender Status Entered..!\n\nEnter Your Gender (Male/Female/Others):");
                    goto gender_adder;
                }
                //-------------------------------------------------------------------------
                Console.Write("\n\nEnter Your Date of Birth (DD/MM/YYYY):");

            dob_adder:
                dateOfBirth = Console.ReadLine().ToLower();
                if (dateOfBirth == null || dateOfBirth == "" || dateOfBirth == " ")
                {
                    Console.Write("\nInvalid Date of Birth. Field should not be null..!\n\nEnter Your Date of Birth (DD/MM/YYYY):");
                    goto dob_adder;
                }
                else if (dateOfBirth.Length != 10)
                {
                    Console.Write("\nInvalid Date of Birth Entered..!\n\nEnter Your Date of Birth in given format - (DD/MM/YYYY):");
                    goto dob_adder;
                }
                // ------------------------------------------------------------------------------------
                // Marital Status:
                Console.Write("\n\nEnter Your Marital Status (Single/Married/Divorced/Widowed):");

            marital_adder:
                maritalStatus = Console.ReadLine().ToLower();
                if (maritalStatus == null || maritalStatus == "" || maritalStatus == " ")
                {
                    Console.Write("\nInvalid Marital Status. Field should not be null..!\n\nEnter Your Marital Status (Single/Married/Divorced/Widowed):");
                    goto marital_adder;
                }
                else if (!(maritalStatus == "single" || maritalStatus == "married" || maritalStatus == "widowed" || maritalStatus == "divorced"))
                {
                    Console.Write("\nInvalid Marital Status Entered..!\n\nEnter Your Marital Status (Single/Married/Divorced/Widowed):");
                    goto marital_adder;
                }

                if (maritalStatus == "married")
                {
                    Console.Write("\n\n    Enter Your Spouse Full Name:");
                spouse_namer:
                    string spouse_name = Console.ReadLine();

                    if (spouse_name == null || spouse_name == " " || spouse_name == "")
                    {
                        Console.Write("\nSpouse Full name should be not null..!\n\n    Enter Your Spouse Full Name:");
                        goto spouse_namer;
                    }
                    else if (spouse_name.Contains("1") || spouse_name.Contains("2") || spouse_name.Contains("3") || spouse_name.Contains("4") || spouse_name.Contains("5") || spouse_name.Contains("6") || spouse_name.Contains("7") || spouse_name.Contains("8") || spouse_name.Contains("9") || spouse_name.Contains("0"))
                    {
                        Console.Write("\nFull Name letters should be alphabets...!\n\n    Enter Your Spouse Full Name:");
                        goto spouse_namer;
                    }
                    Console.Write("\n\nHow Many Childrens Do You Have: ");
                    int child_count = Convert.ToInt32(Console.ReadLine());
                    if (child_count >= 1)
                    {
                        for (int t1 = 0; t1 < child_count; t1++)
                        {
                            Console.Write("\n\n   Enter the {0} Child Full Name:", t1);
                            string children_names = null;
                        child_namer:
                            children_names = Console.ReadLine();

                            if (children_names == null || children_names == " " || children_names == "")
                            {
                                Console.Write("\nChild Full name should be not null..!\n\n   Enter the {0} Child Full Name:", t1);
                                goto child_namer;
                            }
                            else if (children_names.Contains("1") || children_names.Contains("2") || children_names.Contains("3") || children_names.Contains("4") || children_names.Contains("5") || children_names.Contains("6") || children_names.Contains("7") || children_names.Contains("8") || children_names.Contains("9") || children_names.Contains("0"))
                            {
                                Console.Write("\nFull Name letters should be alphabets...!\n\n   Enter the {0} Child Full Name:", t1);
                                goto child_namer;
                            }

                        }
                    }
                }



                // ------------------------------------------------------------------------------------------------------
                // Address Validator
                Console.Write("\n\nEnter Your Permanent Address (As Per Govt Id Proof):");

            permanent_addrs:
                permanentAddress = Console.ReadLine().ToLower();
                if (permanentAddress == null || permanentAddress == "" || permanentAddress == " ")
                {
                    Console.Write("\nInvalid Permanent Address. Field should not be null..!\n\nEnter Your Permanent Address (As Per Govt Id Proof):");
                    goto permanent_addrs;
                }
                else if (permanentAddress.Length >= 20)
                {
                    Console.Write("\n\nEnter Your Full Permanent Address (As Per Govt Id Proof):");
                    goto permanent_addrs;
                }
                Console.Write("\n\nCommunication Address is same as Permanent Address (y/n)?: ");
            choice_chk:
                string h1 = Console.ReadLine();
                if (h1 == "yes" || h1 == "Yes" || h1 == "y" || h1 == "Y")
                {
                    communicationAddress = permanentAddress;
                }
                else if (h1 == "n" || h1 == "No" || h1 == "N" || h1 == "no")
                {
                    Console.Write("\n\nEnter Your Communication Address (As Per Current Address Id Proof):");
                communication_addrs:
                    communicationAddress = Console.ReadLine();
                    if (communicationAddress == null || communicationAddress == "" || communicationAddress == " ")
                    {
                        Console.Write("\nInvalid Communication Address. Field should not be null..!\n\nEnter Your Communication Address (As Per Current Address Id Proof):");
                        goto communication_addrs;
                    }
                    else if (communicationAddress.Length >= 20)
                    {
                        Console.Write("\n\nEnter Your Full Communication Address (As Per Current Address Id Proof):");
                        goto communication_addrs;
                    }
                }
                else
                {
                    Console.Write("\n\nEnter The Correct Choice..!\n\nCommunication Address is same as Permanent Address (y/n)?: ");
                    goto choice_chk;
                }

                // --------------------------------------------------------------------------
                // Random Generated Account Number:

                Random rand1 = new Random();
                long acc_no = rand1.Next();


                // ------------------------------------------------------------------------------
                // Credit Card
                Console.Write("\n\nDo You want credit card (y/n)?: ");
                string h2 = Console.ReadLine();
                if (h2 == "yes" || h2 == "Yes" || h2 == "y" || h2 == "Y")
                {
                    Console.Write("\n    Enter Your Currently Fixed Salary:");
                salary_chk:
                    long salary = Convert.ToInt64(Console.ReadLine());
                    
                    if (salary >= 500000)
                    {
                        creditAmountLimit = 63500;
                        Console.WriteLine("Congratulations. You are elegible to get credit card amount: {0}", creditAmountLimit);
                    }
                    else if(salary >= 250000 || salary <= 500000)
                    {
                        creditAmountLimit = 23500;
                        Console.WriteLine("Congratulations. You are elegible to get credit card amount: {0}", creditAmountLimit);
                    }
                    else
                    {
                        Console.WriteLine("Sorry. You are not elegible to get credit card amount...!");
                    }
                }
                else if (h2 == "n" || h2 == "No" || h2 == "N" || h2 == "no")
                {
                    h2 = "No";
                }
                else
                {
                    Console.Write("\n\nEnter The Correct Choice..!\n\nDo You want credit card (y/n)?: ");
                    goto choice_chk;
                }
                Random rand2 = new Random();
                long creditCardNumber = rand2.Next();

             
                Console.WriteLine("\n\n-----------------++++++++++++++Account Creation Summary++++++++++++++-----------------\n\n");
                Console.WriteLine("Bank Name: Bank Of Pune\n");
                Console.WriteLine("Bank Branch Name: Pune Branch, Maharashtra\n");
                Console.WriteLine("Account Number: {0}\n",acc_no);
                Console.WriteLine("Credit Card Number: {0}\n", creditCardNumber);
                Console.WriteLine("Credit Card Amount Limit: {0}",creditAmountLimit);
                Console.WriteLine("\n\n=====================Personal Details=====================\n");
                Console.WriteLine("Full Name: {0} {1} {2}\n", firstName,middleName, lastName);
                Console.WriteLine("Permanent Account Number: {0} \n", panNumber);
                Console.WriteLine("Registered Phone Number: {0} \n", phoneNumber);
                Console.WriteLine("Gender: {0}\n", gender);
                Console.WriteLine("Date Of Birth: {0}\n", dateOfBirth);
                Console.WriteLine("Marital Status: {0}\n", maritalStatus);
                Console.WriteLine("Permanent Address: {0}\n",permanentAddress);
                Console.WriteLine("Current Communication Address: {0}\n", communicationAddress);



                // ----------------------------------------------------------------------

                Console.Write("\nDo You want to create another account (y/n)?");
                    string next_iteration = null;
                    next_iteration = Console.ReadLine();
                    if (next_iteration == "yes" || next_iteration == "Yes" || next_iteration == "y" || next_iteration == "Y")
                    {
                        m = true;
                        i++;
                    }
                    else if (next_iteration == "No" || next_iteration == "No" || next_iteration == "N" || next_iteration == "n")
                    {
                        Console.Write("\n\n+++++-------Thank You For Using Our Bank-------+++++");
                        m = false;
                    }
                    else
                    {
                        Console.Write("\n\n+++++-------Thank You For Using Our Bank-------+++++");
                        m = false;
                    }
            }
        }
    }
}
*/