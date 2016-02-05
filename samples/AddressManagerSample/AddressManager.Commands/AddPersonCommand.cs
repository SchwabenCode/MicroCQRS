using SchwabenCode.MicroCQRS;

namespace AddressManager.Commands
{
    public class AddPersonCommand : ICommand
    {
        public string Firstname { get; }
        public string Lastname { get; }

        public AddPersonCommand( string firstname, string lastname )
        {
            Firstname = firstname;
            Lastname = lastname;
        }
    }
}
