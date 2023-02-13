/*
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KYC_Form
{
    class Program
    {
        static void Main(string[] args)
        {
            KYCForm form = new KYCForm();
            form.FirstName = "John";
            form.LastName = "Doe";
            form.Email = "johndoe@email.com";
            form.Age = 25;
            form.PhoneNumber = "555-555-5555";
            form.Address = "123 Main St";

            try
            {
                form.Submit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }
    }

    class KYCForm
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private int _age;
        private string _phoneNumber;
        private string _address;

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        [Required(ErrorMessage = "Age is required.")]
        [Range(18, 120, ErrorMessage = "Age must be between 18 and 120.")]
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        [Required(ErrorMessage = "Address is required.")]
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public void Submit()
        {
            List<ValidationResult> results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(this);
            if (!Validator.TryValidateObject(this, context, results, true))
            {
                foreach (ValidationResult result in results)
                {
                    throw new Exception(result.ErrorMessage);
                }
            }
            else
            {
                Console.WriteLine("KYC form submitted successfully.");
            }
        }
    }
}

*/