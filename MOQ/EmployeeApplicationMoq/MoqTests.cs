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
        public void MockAndverifyMethodCallTest()   //메소드 mock
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
            bool value = pf.IsPFEligible(650);  //왜 여기선 method를 mock할 필요가 없지?

            //assert
            Assert.True(value);

            //check method call based on number of times
            mock.Verify(x=>x.GetEmployeeSalary(It.IsAny<int>()), Times.Exactly(2)); //GetEmployeeSalary가 얼마나 콜 되는지 검사
        }

        [Test]
        public void MockAndverifyPropertyCallTest() //프로퍼티 mock
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

        //메소드는 하나하나 mock해야하지만
        //프로퍼티는 한꺼번에 mock할 수 있다.
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
        public void MockMethodCallTest()   //메소드 mock
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