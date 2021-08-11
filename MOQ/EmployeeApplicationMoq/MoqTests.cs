using EmployeeApplication.Model;
using NUnit.Framework;
using Moq;

namespace EmployeeApplicationMoq
{
    public class MoqTests
    {
        [Test]
        public void ActualMethodCallTest()
        {
            //arrange - create
            var pf = new EmployeePFDetails(new EmployeeDetails());

            //act(test)
            double contribution = pf.GetEmployerContribution(2);

            //assert(verify)
            Assert.AreEqual(5000 * .12, contribution);
        }
        [Test]
        public void MockAndverifyMethodCallTest()   //�޼ҵ� mock
        {
            //will mock GetEmployeeSarary(empId)

            //arrange - create
            var mock = new Mock<IEmployeeDetails>(); // mock object for EmployeeDetails
            var pf = new EmployeePFDetails(mock.Object);

            //mock the method
            mock.Setup(x => x.GetEmployeeSalary(It.IsAny<int>())).Returns(1000);
            //mock.Setup(x => x.GetEmployeeRole(5)).Returns("Manager");

            //act(test)
            double contribution = pf.GetEmployerContribution(2);            

            //assert(verify)
            Assert.AreEqual(1000 * .12, contribution);

            //act
            bool value = pf.IsPFEligible(650);  //�� ���⼱ method�� mock�� �ʿ䰡 ����?

            //assert
            Assert.True(value);

            //check method call based on number of times
            mock.Verify(x=>x.GetEmployeeSalary(It.IsAny<int>()), Times.Exactly(2)); //GetEmployeeSalary�� �󸶳� �� �Ǵ��� �˻�
        }

        [Test]
        public void MockAndverifyPropertyCallTest() //������Ƽ mock
        {
            //arrange
            var mock = new Mock<IEmployeeDetails>();
            var pf = new EmployeePFDetails(mock.Object);

            //mock the property
            mock.Setup(x => x.CompanyName).Returns("Sollers");

            //act
            string compName = pf.GetCompanyName();

            pf.PrintCompanyDetail();
            //assert
            Assert.AreEqual("Sollers", compName);

        }

        //stubbing  --  setting the property values
        [Test]
        public void MockAndverifyProperty2CallTest()
        {
            //arrange
            var mock = new Mock<IEmployeeDetails>();
            var pf = new EmployeePFDetails(mock.Object);

        //�޼ҵ�� �ϳ��ϳ� mock�ؾ�������
        //������Ƽ�� �Ѳ����� mock�� �� �ִ�.
            //mock.SetupAllProperties();                
            //mock.Object.UniqueCode = 10004;
            //mock.Object.

            //mock the property  //stubbing
            mock.SetupProperty(x => x.CompanyName, "Google");
            //mock.SetupProperty(x => x.UniqueCode, It.IsAny<int>());
            mock.SetupProperty(x => x.UniqueCode, 90001);

            //act
            string compName = pf.GetCompanyName();

            pf.PrintCompanyDetail();
            //assert
            Assert.AreEqual("Sollers", compName);
        }

        //loose moq --> not check whether method or properties mocked explicitly
        [Test]
        public void MockMethodCallTest()   //�޼ҵ� mock
        {
            //will mock GetEmployeeSarary(empId)

            //arrange - create
            var mock = new Mock<IEmployeeDetails>(); // mock object for EmployeeDetails
            var pf = new EmployeePFDetails(mock.Object);

            //act(test)
            double contribution = pf.GetEmployerContribution(2);

            //assert(verify)
            Assert.AreEqual(1000 * .12, contribution);
        }

        //strict moq --> check whether method or properties mocked explicitly otherwise throw error
        [Test]
        public void MockMethodStrictCallTest()  
        {
            //will mock GetEmployeeSarary(empId)

            //arrange - create
            var mock = new Mock<IEmployeeDetails>(MockBehavior.Strict);
            var pf = new EmployeePFDetails(mock.Object);

            //mock and properties should be STRICTLY mocked!!!!
            mock.Setup(x => x.GetEmployeeSalary(It.IsAny<int>())).Returns(1000);
            mock.Setup(x => x.GetEmployeeSalary(It.IsAny<int>())).Returns(60000);
            mock.SetupProperty(x => x.CompanyName, "Google");
            mock.SetupProperty(x => x.UniqueCode, 90001);

            //act(test)
            double contribution = pf.GetEmployerContribution(2);

            //assert(verify)
            Assert.AreEqual(1000 * .12, contribution);
        }
    }
}