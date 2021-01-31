using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EGovernment.App_Code
{
    public class MarriageDocument
    {
        private Couple husband;// الزوج
        private Couple wife; // الزوجة
        private string issuedBy; // صادر عن أمانة
        private string governorate;// في محافظة
        private string familyNumber;//الرقم الأسري
        private DateTime dateContract;//تاريخ العقد
        private string authorityAuthorizedContract;// السلطة التي أجازت العقد
        private string documentNumber;// رقم الوثيقة
        private DateTime dateDocument;// تاريخ الوثيقة
        private string notes;// ملاحظات
        private string nameController;// اسم المراقب
        private string registrarIn;// أمين السجل المدني في
        private string nameRegistrar;// اسم أمين السجل المدني

        public MarriageDocument(Couple husband, Couple wife, string issuedBy, string governorate, string familyNumber, DateTime dateContract, string authorityAuthorizedContract, string documentNumber, DateTime dateDocument, string notes, string nameController, string registrarIn, string nameRegistrar)
        {
            this.husband = husband;
            this.wife = wife;
            this.issuedBy = issuedBy;
            this.governorate = governorate;
            this.familyNumber = familyNumber;
            this.dateContract = dateContract;
            this.authorityAuthorizedContract = authorityAuthorizedContract;
            this.documentNumber = documentNumber;
            this.dateDocument = dateDocument;
            this.notes = notes;
            this.nameController = nameController;
            this.registrarIn = registrarIn;
            this.nameRegistrar = nameRegistrar;
        }

        public Couple Husband
        {
            get
            {
                return husband;
            }

            set
            {
                husband = value;
            }
        }

        public Couple Wife
        {
            get
            {
                return wife;
            }

            set
            {
                wife = value;
            }
        }

        public string IssuedBy
        {
            get
            {
                return issuedBy;
            }

            set
            {
                issuedBy = value;
            }
        }

        public string Governorate
        {
            get
            {
                return governorate;
            }

            set
            {
                governorate = value;
            }
        }

        public string FamilyNumber
        {
            get
            {
                return familyNumber;
            }

            set
            {
                familyNumber = value;
            }
        }

        public DateTime DateContract
        {
            get
            {
                return dateContract;
            }

            set
            {
                dateContract = value;
            }
        }

        public string AuthorityAuthorizedContract
        {
            get
            {
                return authorityAuthorizedContract;
            }

            set
            {
                authorityAuthorizedContract = value;
            }
        }

        public string DocumentNumber
        {
            get
            {
                return documentNumber;
            }

            set
            {
                documentNumber = value;
            }
        }

        public DateTime DateDocument
        {
            get
            {
                return dateDocument;
            }

            set
            {
                dateDocument = value;
            }
        }

        public string Notes
        {
            get
            {
                return notes;
            }

            set
            {
                notes = value;
            }
        }

        public string NameController
        {
            get
            {
                return nameController;
            }

            set
            {
                nameController = value;
            }
        }

        public string RegistrarIn
        {
            get
            {
                return registrarIn;
            }

            set
            {
                registrarIn = value;
            }
        }

        public string NameRegistrar
        {
            get
            {
                return nameRegistrar;
            }

            set
            {
                nameRegistrar = value;
            }
        }
    }
    public class Person
    {
        private string firstName;
        private string lastName;
        private string idNumber;

        public Person(string firstName, string lastName, string idNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.IdNumber = idNumber;
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        public string IdNumber
        {
            get
            {
                return idNumber;
            }

            set
            {
                idNumber = value;
            }
        }
    }
    public class Couple
    {
        private Person onePerson;// زوج او زوجة
        private Person father;
        private Person mother;
        private string placeBirth;
        private DateTime dateBith;
        private string religion;
        private string nationality;
        private string alamana;// الأمانة
        private string placeEntry;// القيد
        private string registrationNumber; // رقم القيد

        public Couple(Person onePerson, Person father, Person mother, string placeBirth, DateTime dateBith, 
            string religion, string nationality, string alamana, string placeEntry, string registrationNumber)
        {
            this.OnePerson = onePerson;
            this.Father = father;
            this.Mother = mother;
            this.PlaceBirth = placeBirth;
            this.DateBith = dateBith;
            this.Religion = religion;
            this.Nationality = nationality;
            this.Alamana = alamana;
            this.PlaceEntry = placeEntry;
            this.RegistrationNumber = registrationNumber;
        }

        public Person OnePerson
        {
            get
            {
                return onePerson;
            }

            set
            {
                onePerson = value;
            }
        }

        public Person Father
        {
            get
            {
                return father;
            }

            set
            {
                father = value;
            }
        }

        public Person Mother
        {
            get
            {
                return mother;
            }

            set
            {
                mother = value;
            }
        }

        public string PlaceBirth
        {
            get
            {
                return placeBirth;
            }

            set
            {
                placeBirth = value;
            }
        }

        public DateTime DateBith
        {
            get
            {
                return dateBith;
            }

            set
            {
                dateBith = value;
            }
        }

        public string Religion
        {
            get
            {
                return religion;
            }

            set
            {
                religion = value;
            }
        }

        public string Nationality
        {
            get
            {
                return nationality;
            }

            set
            {
                nationality = value;
            }
        }

        public string Alamana
        {
            get
            {
                return alamana;
            }

            set
            {
                alamana = value;
            }
        }

        public string PlaceEntry
        {
            get
            {
                return placeEntry;
            }

            set
            {
                placeEntry = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return registrationNumber;
            }

            set
            {
                registrationNumber = value;
            }
        }
    }
}