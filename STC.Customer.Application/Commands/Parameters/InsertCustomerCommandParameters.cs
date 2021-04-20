using STC.Shared.Cqrs.Command;

namespace STC.Customer.Application.Commands.Parameters
{
    public class InsertCustomerCommandParameters: ICommand
    {
        public InsertCustomerCommandParameters(int age)
        {
            Age = age;
        }

        public int Age { get; set; }
    }
}
