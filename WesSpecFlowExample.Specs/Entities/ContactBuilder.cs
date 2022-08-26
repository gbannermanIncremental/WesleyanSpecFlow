
namespace WesSpecFlowExample.Entities
{
    class ContactBuilder
    {

        public Contact BuildHospitalDoctor()
        {
            Contact doctor = new Contact();
            doctor.ContactType = "Customer";
            doctor.Segment = "Hospital Doctor";
            doctor.FirstName = "Hospital";
            doctor.LastName = "Doctor";
            doctor.NameSuffix = "-acsdsd";
            doctor.MobileNumber = "07771727272";
            doctor.AddressType = "Home";
            doctor.Address = "99 Red lane";
            doctor.PostCode = "BH12 1AE";
            return doctor;
        }

        public Contact BuildJaneDoe()
        {
            Contact janeDoe = new Contact();
            janeDoe.ContactType = "Customer";
            janeDoe.Segment = "Hospital Doctor";
            janeDoe.FirstName = "Jane";
            janeDoe.LastName = "Doe";
            janeDoe.NameSuffix = "-acsdsd";
            janeDoe.MobileNumber = "07771727272";
            janeDoe.AddressType = "Home";
            janeDoe.Address = "99 Red lane";
            janeDoe.PostCode = "BH12 1AE";
            return janeDoe;
        }
    }
}
