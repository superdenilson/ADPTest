# ADPTest
#This project was built using .NET 6
#The endpoint exposed has no parameters, it only gets a task provided by https://interview.adpeai.com/api/v1/get-task and then identifies and executes the operation:
# addition, substraction, multiplication, division and reminder. After executing the operation, the result is submitted using https://interview.adpeai.com/api/v1/submit-task endpoint
#The solution is composed by 3 projects:
#ADPTest.WebAPI: the user interface of the API, providing also a swagger for testing and documentation purposes
#ADPTest.Infrastructure: responsible for all service interface implementations and communication with external service
#ADPTest.SharedKernele: contains interfaces, enums, dependency injection and any other piece of code that can be shared by other assemblies
#IOptions Pattern was used to retrieve configuration options
#There are three interfaces: 
#IExternalServices, which exposes the external endpoints in the https://interview.adpeai.com/api API
#ITaskService, to implement the process of getting a task, execute the corresponding operation ad submit the result
#IOperationService, to implement each operation itself
