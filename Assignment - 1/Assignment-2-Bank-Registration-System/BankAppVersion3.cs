
using System.Text.RegularExpressions;

namespace Assignment_2_Bank_Registration_System
{
    internal class BankAppVersion3
    {
        static void Main(string[] args)
        {
            BankAccountOperations AccountObj1 = new BankAccountOperations();
            AccountObj1.BankAccountOperationsFunction();
        }
    }
    internal class AllUserDetails
    {
        protected long accountBalance;
        protected string firstName = null;
        protected string lastName = "";
        protected string middleName = "";
        protected string emailId = "";
        protected long phoneNumber = 0;
        protected string gender = "";
        protected string panNumber = "";
        protected string dateOfBirth = "";
        protected string maritalStatus = "";// {"single","married","divorced","widowed"}
        protected string permanentAddress = "";
        protected string communicationAddress = "";
        private long creditAmountLimit = 0;
        protected Regex regexForOnlyNumber = new Regex(@"[\d]$");
        protected Regex regexForAlphaOnly = new Regex(@"[\d]");
        protected bool AnotherAccountCreationStatus;
        protected int i = 0;
        protected int accountPinNumber = 0;
        protected long salary = 0;
        protected long creditCardNumber = 0;
        protected long accountNumber = 0;
        protected string createAnotherAccount = "";
        protected string userCreditCardChoice = "";
        internal AllUserDetails()
        {

            do
            {
                Console.WriteLine("\n================++++++WELCOME TO BANK OF PUNE++++++================\n\n");
                // new user entry
                Console.WriteLine("Create Your Personal Details:\n");
                Console.Write("\nEnter Your First Name:");
            gotoFirstName:
                firstName = Console.ReadLine();  // You need to enter fname second time only if our validations throws error for your input..!
                // Null Content validation checking
                if (string.IsNullOrEmpty(firstName) || string.IsNullOrWhiteSpace(firstName))
                {
                    Console.Write("\nFirst name should be not null..!\n\nEnter Your First Name:");
                    goto gotoFirstName;
                }
                else if (regexForAlphaOnly.IsMatch(firstName))
                {
                    Console.Write("\nFirst Name letters should be alphabets...!\n\nEnter Your First Name:");
                    goto gotoFirstName;
                }
                Console.Write("\nEnter Your Middle Name (Optional):");
            gotoMiddleName:
                middleName = Console.ReadLine();
                if (regexForAlphaOnly.IsMatch(middleName))
                {
                    Console.Write("\nMiddle Name letters should be alphabets...!\n\nEnter Your Middle Name:");
                    goto gotoMiddleName;
                }
                Console.Write("\n\nEnter Your Last Name:");
            gotoLastName:
                lastName = Console.ReadLine();
                if (string.IsNullOrEmpty(lastName) || string.IsNullOrWhiteSpace(lastName))
                {
                    Console.Write("\nLast name should not be null..!\n\nEnter Your List Name:");
                    goto gotoLastName;
                }
                else if (regexForAlphaOnly.IsMatch(lastName))
                {
                    Console.Write("\nLast Name letters should be alphabets...!\n\nEnter Your Last Name:");
                    goto gotoLastName;
                }
                Console.Write("\n\nEnter Your Email ID:");
            gotoEmailId:
                emailId = Console.ReadLine().ToLower();

                if (string.IsNullOrEmpty(emailId) || string.IsNullOrWhiteSpace(emailId))
                {
                    Console.Write("\nEmail Id  should not be null..!\n\nEnter Your Email Id:");
                    goto gotoEmailId;
                }
                else if (!(emailId.EndsWith("@outlook.com") || emailId.EndsWith("@gmail.com") || emailId.EndsWith("@incubxperts.com")))
                {
                    Console.Write("\nEnter Correct Email Id Domain...!\nEmail Id Domains(gmail,outlook,incubxperts)\n\nEnter Your Email Id:");
                    goto gotoEmailId;
                }
                Console.Write("\n\nEnter Your Phone Number:");

            phoneNumberAdder:
                string phno = Console.ReadLine();

                if (!(regexForOnlyNumber.IsMatch(phno)))
                {
                    Console.Write("\nAll the values should be numeric..!\n\nEnter Your Phone Number:");
                    goto phoneNumberAdder;
                }
                else
                {
                    phoneNumber = Convert.ToInt64(phno);
                }
                if (phoneNumber == null || phoneNumber == 0)
                {
                    Console.Write("\nInvalid Phone Number should not be null..!\n\nEnter Your Phone Number:");
                    goto phoneNumberAdder;
                }
                if ((Convert.ToString(phoneNumber)).Length == 12)
                {
                    Console.Write("\nDon't add the country code in phone number..!\n\nEnter Your Phone Number:");
                    goto phoneNumberAdder;
                }
                else if ((Convert.ToString(phoneNumber)).Length != 10)
                {
                    Console.Write("\nInvalid Phone Number Entered..!\n\nEnter Your Phone Number:");
                    goto phoneNumberAdder;
                }
                //-------------------------------------------------------------------
                // PAN Details:
                Console.Write("\n\nEnter Your Permanent Account Number(PAN):");

            panAdder:
                panNumber = Console.ReadLine();
                if (string.IsNullOrEmpty(panNumber) || string.IsNullOrWhiteSpace(panNumber))
                {
                    Console.Write("\nInvalid PAN Card. Field should not be null..!\n\nEnter Your Permanent Account Number(PAN):");
                    goto panAdder;
                }
                else if (panNumber.Length != 10)
                {
                    Console.Write("\nInvalid PAN Card Number Entered..!\n\nEnter Your Permanent Account Number(PAN):");
                    goto panAdder;
                }
                // --------------------------------------------------------------------------
                Console.Write("\n\nEnter Your Gender (male/female/others):");

            genderAdder:
                gender = Console.ReadLine().ToLower();
                if (string.IsNullOrEmpty(gender) || string.IsNullOrWhiteSpace(gender))
                {
                    Console.Write("\nInvalid Gender Status. Field should not be null..!\n\nEnter Your Gender (Male/Female/Others):");
                    goto genderAdder;
                }
                else if (!(gender == "male" || gender == "female" || gender == "others" || gender == "m" || gender == "f" || gender == "o"))
                {
                    Console.Write("\nInvalid Gender Status Entered..!\n\nEnter Your Gender (Male/Female/Others):");
                    goto genderAdder;
                }

                Console.Write("\n\nEnter Your Date of Birth (MM/DD/YYYY):");

            dateOfBirthAdder:
                dateOfBirth = Console.ReadLine().ToLower();

                if (string.IsNullOrEmpty(dateOfBirth) || string.IsNullOrWhiteSpace(dateOfBirth))
                {
                    Console.Write("\nInvalid Date of Birth. Field should not be null..!\n\nEnter Your Date of Birth (MM/DD/YYYY):");
                    goto dateOfBirthAdder;
                }
                else if (dateOfBirth.Length != 10)
                {
                    Console.Write("\nInvalid Date of Birth Entered..!\n\nEnter Your Date of Birth in given format - (MM/DD/YYYY):");
                    goto dateOfBirthAdder;
                }
                string[] dateParts = dateOfBirth.Split('/');
                DateTime testDate = new DateTime(Convert.ToInt32(dateParts[2]), Convert.ToInt32(dateParts[0]),
                Convert.ToInt32(dateParts[1]));
                if (Convert.ToInt16(dateParts[2]) >= 2004)
                {
                    Console.WriteLine("To Create Your Account. Your Age Should be Above 18 Years.");
                    Console.Write("\n\n+++++-------Thank You For Using Our Bank-------+++++");
                    Environment.Exit(0);
                }
                
                    
                
                // ------------------------------------------------------------------------------------
                // Marital Status:
                Console.Write("\n\nEnter Your Marital Status (Single/Married/Divorced/Widowed):");

            maritalStatusChecker:
                maritalStatus = Console.ReadLine().ToLower();
                if (string.IsNullOrEmpty(maritalStatus) || string.IsNullOrEmpty(maritalStatus))
                {
                    Console.Write("\nInvalid Marital Status. Field should not be null..!\n\nEnter Your Marital Status (Single/Married/Divorced/Widowed):");
                    goto maritalStatusChecker;
                }
                else if (!(maritalStatus == "single" || maritalStatus == "married" || maritalStatus == "widowed" || maritalStatus == "divorced"))
                {
                    Console.Write("\nInvalid Marital Status Entered..!\n\nEnter Your Marital Status (Single/Married/Divorced/Widowed):");
                    goto maritalStatusChecker;
                }

                if (maritalStatus == "married")
                {
                    Console.Write("\n\n    Enter Your Spouse Full Name:");
                spouseNameChecker:
                    string spouseName = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(spouseName) || string.IsNullOrEmpty(spouseName))
                    {
                        Console.Write("\nSpouse Full name should be not null..!\n\n    Enter Your Spouse Full Name:");
                        goto spouseNameChecker;
                    }
                    else if (regexForAlphaOnly.IsMatch(spouseName))
                    {
                        Console.Write("\nFull Name letters should be alphabets...!\n\n    Enter Your Spouse Full Name:");
                        goto spouseNameChecker;
                    }
                    Console.Write("\n\nHow Many Childrens Do You Have: ");
                    childCountChecker:
                    int childCount = Convert.ToInt32(Console.ReadLine());
                    if (childCount >= 0)
                    {
                        int childCounter = 1;
                        for (int t1 = 0; t1 < childCount; t1++)
                        {
                            Console.Write("\n\n   Enter the {0} Child Full Name:", childCounter);
                            string[] childrenNames = new string[10];
                        childrensNameChecker:
                            childrenNames[t1] = Console.ReadLine();

                            if (string.IsNullOrEmpty(childrenNames[t1]) || string.IsNullOrWhiteSpace(childrenNames[t1]))
                            {
                                Console.Write("\nChild Full name should be not null..!\n\n   Enter the {0} Child Full Name:", childCounter);
                                goto childrensNameChecker;
                            }
                            else if (regexForAlphaOnly.IsMatch(childrenNames[t1]))
                            {
                                Console.Write("\nFull Name letters should be alphabets...!\n\n   Enter the {0} Child Full Name:", childCounter++);
                                goto childrensNameChecker;
                            }
                            childCounter++;

                        }
                    }
                    else 
                    {
                        Console.Write("\n\nInvaild Input Entered..!\nEnter Correct Child Count: ");
                        goto childCountChecker;
                    }
                }



                // ------------------------------------------------------------------------------------------------------
                // Address Validator
                Console.Write("\n\nEnter Your Permanent Address (As Per Govt Id Proof):");

            permanentAddress:
                permanentAddress = Console.ReadLine().ToLower();
                if (string.IsNullOrWhiteSpace(permanentAddress) || string.IsNullOrEmpty(permanentAddress))
                {
                    Console.Write("\nInvalid Permanent Address. Field should not be null..!\n\nEnter Your Permanent Address (As Per Govt Id Proof):");
                    goto permanentAddress;
                }
                else if (permanentAddress.Length <= 20)
                {
                    Console.Write("\n\nInvalid Address...! (Address length should be above 20 characters)\nEnter Your Full Permanent Address (As Per Govt Id Proof):");
                    goto permanentAddress;
                }
                Console.Write("\n\nCommunication Address is same as Permanent Address (y/n)?: ");
            choiceChecker:                
                string h1 = Console.ReadLine();
                if (h1 == "yes" || h1 == "Yes" || h1 == "y" || h1 == "Y")
                {
                    communicationAddress = permanentAddress;
                }
                else if (h1 == "n" || h1 == "No" || h1 == "N" || h1 == "no")
                {
                    Console.Write("\n\nEnter Your Communication Address (As Per Current Address Id Proof):");
                communicationAddress:
                    communicationAddress = Console.ReadLine();
                    if (string.IsNullOrEmpty(communicationAddress) || string.IsNullOrWhiteSpace(communicationAddress))
                    {
                        Console.Write("\nInvalid Communication Address. Field should not be null..!\n\nEnter Your Communication Address (As Per Current Address Id Proof):");
                        goto communicationAddress;
                    }
                    else if (communicationAddress.Length <= 20)
                    {
                        Console.Write("\n\nInvalid Address...! (Address length should be above 20 characters)\n Enter Your Full Communication Address (As Per Current Address Id Proof):");
                        goto communicationAddress;
                    }
                }
                else
                {
                    Console.Write("\n\nEnter The Correct Choice..!\n\nCommunication Address is same as Permanent Address (y/n)?: ");
                    goto choiceChecker;
                }

                // --------------------------------------------------------------------------
                // Random Generated Account Number:

                Random accountNumberGenerator = new Random();
                accountNumber = accountNumberGenerator.Next();


                // ------------------------------------------------------------------------------

                // Credit Card class
                Console.Write("\n\nDo You want credit card (y/n)?: ");
                userCreditCardChoice = "no";
            creditChoiceCheck:
                userCreditCardChoice = Console.ReadLine();
                if (userCreditCardChoice == "yes" || userCreditCardChoice == "Yes" || userCreditCardChoice == "y" || userCreditCardChoice == "Y")
                {
                    Console.Write("\n    Enter Your Currently Fixed Salary:");
                salaryChecker:
                    string salaryString = Console.ReadLine();
                    if (string.IsNullOrEmpty(salaryString) || string.IsNullOrWhiteSpace(salaryString))
                    {
                        Console.Write("\nEnter The Valid salary.Field should not be Empty..!\n    Enter Your Currently Fixed Salary:");
                        goto salaryChecker;
                    }
                    else if (!(regexForAlphaOnly.IsMatch(salaryString)))
                    {
                        Console.Write("\nEnter The Valid salary.Field should not be Empty..!\n    Enter Your Currently Fixed Salary:");
                        goto salaryChecker;
                    }
                    salary = Convert.ToInt64(salaryString);
                    if (salary >= 500000)
                    {
                        creditAmountLimit = 63500;
                        Console.WriteLine("Congratulations. You are elegible to get credit card amount: {0}", creditAmountLimit);
                        Random creditCardRandomNumberGeneration = new Random();
                        creditCardNumber = creditCardRandomNumberGeneration.Next();
                    }
                    else if (salary >= 250000 && salary < 500000)
                    {
                        creditAmountLimit = 23500;
                        Console.WriteLine("Congratulations. You are elegible to get credit card amount: {0}", creditAmountLimit);
                        Random creditCardRandomNumberGeneration = new Random();
                        creditCardNumber = creditCardRandomNumberGeneration.Next();
                    }
                    else
                    {
                        Console.WriteLine("Sorry. You are not elegible to get credit card amount...!");
                    }
                }
                else if (userCreditCardChoice == "n" || userCreditCardChoice == "No" || userCreditCardChoice == "N" || userCreditCardChoice == "no")
                {
                    userCreditCardChoice = "no";
                }
                else
                {
                    Console.Write("\n\nEnter The Correct Choice..!\n\nDo You want credit card (y/n)?: ");
                    goto creditChoiceCheck;
                }
                
                Random accountPinNumberGeneration = new Random();
                accountPinNumber = accountPinNumberGeneration.Next(0000,9999);


                Console.Write("\nDo You want to create another account (y/n)?");
                createAnotherAccount = "No";
                createAnotherAccount = Console.ReadLine();
                if (createAnotherAccount == "yes" || createAnotherAccount == "Yes" || createAnotherAccount == "y" || createAnotherAccount == "Y")
                {
                    AnotherAccountCreationStatus = true;
                    
                }
                else if (createAnotherAccount == "No" || createAnotherAccount == "No" || createAnotherAccount == "N" || createAnotherAccount == "n")
                {
                    Console.Write("\n\n+++++-------Thank You For Using Our Bank-------+++++");
                    AnotherAccountCreationStatus = false;
                    break;
                }
                else
                {
                    Console.Write("\n\n+++++-------Thank You For Using Our Bank-------+++++");
                    AnotherAccountCreationStatus = false;
                    break;
                }


            } while (AnotherAccountCreationStatus == true);
            // ----------------------------------------------------------------------------------------------------
            Console.WriteLine("\n\n-----------------++++++++++++++Account Creation Summary++++++++++++++-----------------\n\n");
            Console.WriteLine("\n\n=====================Account Details=====================\n");
            Console.WriteLine("Bank Name: Bank Of Pune\n");
            Console.WriteLine("Bank Branch Name: Pune Branch, Maharashtra\n");
            Console.WriteLine("Account Number: {0}\n", accountNumber);
            Console.WriteLine("Current Account Balance: {0}\n", accountBalance);
            Console.WriteLine("Account Auto-Generated PIN Number: {0}\n", accountPinNumber);
            if(userCreditCardChoice == "yes")
            {
                Console.WriteLine("Credit Card Number: {0}\n", creditCardNumber);
                Console.WriteLine("Credit Card Amount Limit: {0}", creditAmountLimit);
            }
            else if(userCreditCardChoice == "y")
            {
                Console.WriteLine("Credit Card Number: {0}\n", creditCardNumber);
                Console.WriteLine("Credit Card Amount Limit: {0}", creditAmountLimit);
            }
            Console.WriteLine("\n\n=====================Personal Details=====================\n");
            Console.WriteLine("Full Name: {0} {1} {2}\n", firstName, middleName, lastName);
            Console.WriteLine("Permanent Account Number: {0} \n", panNumber);
            Console.WriteLine("Registered Phone Number: {0} \n", phoneNumber);
            Console.WriteLine("Gender: {0}\n", gender);
            Console.WriteLine("Date Of Birth: {0}\n", dateOfBirth);
            Console.WriteLine("Marital Status: {0}\n", maritalStatus);
            Console.WriteLine("Permanent Address: {0}\n", permanentAddress);
            Console.WriteLine("Current Communication Address: {0}\n", communicationAddress);

        }
    }


}
