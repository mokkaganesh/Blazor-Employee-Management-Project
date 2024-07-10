/*using EmployeeManagement.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public class ChatbotService
    {
        private readonly ApplicationDbContext _context;

        public ChatbotService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ChatMessage>> GetAllMessagesAsync()
        {
            try
            {
                return await _context.ChatMessages.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching messages: {ex.Message}");
                throw;
            }
        }

        public async Task<ChatMessage> SendMessageAsync(string userMessage)
        {
            try
            {
                var botReply = GetBotReply(userMessage);

                var chatMessage = new ChatMessage
                {
                    UserMessage = userMessage,
                    BotReply = botReply,
                    Timestamp = DateTime.UtcNow
                };

                _context.ChatMessages.Add(chatMessage);
                await _context.SaveChangesAsync();

                return chatMessage;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending message: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
                throw;
            }
        }

        private string GetBotReply(string userMessage)
        {
            if (string.IsNullOrWhiteSpace(userMessage))
            {
                return "Please type a message.";
            }

            userMessage = userMessage.ToLower();

            if (userMessage.Contains("hello") || userMessage.Contains("hi"))
            {
                return "Hello! How can I assist you today?";
            }
            if (userMessage.Contains("departments"))
            {
                return GetDepartments();
            }
            if (userMessage.Contains("employees"))
            {
                return GetEmployees();
            }
            if (userMessage.Contains("company address"))
            {
                return "Our company address is 123 Main St, City, Country.";
            }
            if (userMessage.Contains("help") || userMessage.Contains("support"))
            {
                return "Sure, please contact our support team at support@company.com.";
            }
            if (userMessage.Contains("clear chat history"))
            {
                ClearChatHistoryAsync().Wait(); // Wait for the asynchronous operation to complete
                return "Chat history has been cleared.";
            }

            return "I'm not sure how to answer that. Please try asking something else.";
        }

        private string GetDepartments()
        {
            var departments = _context.Department.Select(d => d.DepartmentName).ToList();
            return $"Here are the departments: {string.Join(", ", departments)}";
        }

        private string GetEmployees()
        {
            var employees = _context.Employee.Select(e => $"{e.FirstName} {e.LastName}").ToList();
            return $"Here are the employees: {string.Join(", ", employees)}";
        }

        private async Task ClearChatHistoryAsync()
        {
            try
            {
                var allMessages = await _context.ChatMessages.ToListAsync();
                _context.ChatMessages.RemoveRange(allMessages);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clearing chat history: {ex.Message}");
                throw;
            }
        }
    }
}
*/
/*
using EmployeeManagement.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public class ChatbotService
    {
        private readonly ApplicationDbContext _context;

        public ChatbotService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ChatMessage>> GetAllMessagesAsync()
        {
            try
            {
                return await _context.ChatMessages.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching messages: {ex.Message}");
                throw;
            }
        }

        public async Task<ChatMessage> SendMessageAsync(string userMessage)
        {
            try
            {
                var botReply = await GetBotReply(userMessage);

                var chatMessage = new ChatMessage
                {
                    UserMessage = userMessage,
                    BotReply = botReply,
                    Timestamp = DateTime.UtcNow
                };

                _context.ChatMessages.Add(chatMessage);
                await _context.SaveChangesAsync();

                return chatMessage;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending message: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
                throw;
            }
        }

        private async Task<string> GetBotReply(string userMessage)
        {
            if (string.IsNullOrWhiteSpace(userMessage))
            {
                return "Please type a message.";
            }

            userMessage = userMessage.ToLower();
            if (userMessage.Contains("clear chat history")|| userMessage.Contains("clear") || userMessage.Contains("clear chat"))
            {
                await ClearChatHistoryAsync(); // Wait for the asynchronous operation to complete

                return "Chat history has been cleared.";
            }

            if (userMessage.Contains("hello") || userMessage.Contains("hi"))
            {
                return "Hello! How can I assist you today?";
            }
            if (userMessage.Contains("departments"))
            {
                return GetDepartments();
            }
            if (userMessage.Contains("employees"))
            {
                return GetEmployees();
            }
            if (userMessage.Contains("company address"))
            {
                return "Our company address is 123 Main St, City, Country.";
            }
            if (userMessage.Contains("help") || userMessage.Contains("support"))
            {
                return "Sure, please contact our support team at support@company.com.";
            }
            
            if (userMessage.Contains("services"))
            {
                return "We offer a variety of services including software development, IT consulting, and project management. How can we assist you?";
            }
            if (userMessage.Contains("mission"))
            {
                return "Our mission is to deliver innovative solutions that drive business success. We aim to exceed client expectations with our dedication to quality and excellence.";
            }
            if (userMessage.Contains("founded") || userMessage.Contains("established"))
            {
                return "Our company was founded in 2010.";
            }
           
            if (userMessage.Contains("contact hr") || userMessage.Contains("hr department"))
            {
                return "You can contact our HR department at hr@company.com.";
            }
          
            if (userMessage.Contains("technical support") || userMessage.Contains("tech support"))
            {
                return "For technical support, please visit our support page at company.com/support or email techsupport@company.com.";
            }
         
            if (userMessage.Contains("department details"))
            {
                return await GetDepartmentDetails();
            }
            if (userMessage.Contains("employees in department"))
            {
                return await GetEmployeesInDepartment(userMessage);
            }
            if (userMessage.Contains("employee details"))
            {
                return await GetEmployeeDetails(userMessage);
            }

            return "I'm not sure how to answer that. Please try asking something else.";
        }

        private string GetDepartments()
        {
            var departments = _context.Department.Select(d => d.DepartmentName).ToList();
            return $"Here are the departments: {string.Join(", ", departments)}";
        }

        private string GetEmployees()
        {
            var employees = _context.Employee.Select(e => $"{e.FirstName} {e.LastName}").ToList();
            return $"Here are the employees: {string.Join(", ", employees)}";
        }

        private async Task<string> GetDepartmentDetails()
        {
            var departments = await _context.Department
                .Select(d => new { d.DepartmentId, d.DepartmentName })
                .ToListAsync();
            return $"Department details: {string.Join(", ", departments.Select(d => $"ID: {d.DepartmentId}, Name: {d.DepartmentName}"))}";
        }

        private async Task<string> GetEmployeesInDepartment(string userMessage)
        {
            var departmentName = userMessage.Split("employees in department ").Last().Trim();
            var department = await _context.Department
                .FirstOrDefaultAsync(d => d.DepartmentName.ToLower() == departmentName.ToLower());

            if (department == null)
            {
                return $"No department found with the name {departmentName}.";
            }

            var employees = await _context.Employee
                .Where(e => e.DepartmentId == department.DepartmentId)
                .Select(e => $"{e.FirstName} {e.LastName}")
                .ToListAsync();

            if (!employees.Any())
            {
                return $"No employees found in the {departmentName} department.";
            }

            return $"Employees in the {departmentName} department: {string.Join(", ", employees)}";
        }

        private async Task<string> GetEmployeeDetails(string userMessage)
        {
            // Extract the integer (ManNumber or EmployeeId) from the user message
            var numberString = new string(userMessage.Where(char.IsDigit).ToArray());

            if (string.IsNullOrEmpty(numberString) || !int.TryParse(numberString, out int number))
            {
                return "Please provide a valid Man Number or Employee ID.";
            }

            // Fetch employee by ManNumber or EmployeeId
            var employee = await _context.Employee
                .FirstOrDefaultAsync(e => e.ManNumber == number || e.EmployeeId == number);

            if (employee == null)
            {
                return $"No employee found with the number {number}.";
            }

            var department = await _context.Department
                .FirstOrDefaultAsync(d => d.DepartmentId == employee.DepartmentId);

            return $"Employee details: Name: {employee.FirstName} {employee.LastName}, Man Number: {employee.ManNumber}, Department: {department?.DepartmentName}";
        }


        private async Task ClearChatHistoryAsync()
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync("DELETE FROM ChatMessages");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clearing chat history: {ex.Message}");
                throw;
            }
        }
    }
}
*/


using EmployeeManagement.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public class ChatbotService
    {
        private readonly ApplicationDbContext _context;

        public ChatbotService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ChatMessage>> GetAllMessagesAsync()
        {
            try
            {
                return await _context.ChatMessages.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching messages: {ex.Message}");
                throw;
            }
        }

        public async Task<ChatMessage> SendMessageAsync(string userMessage)
        {
            try
            {
                var botReply = await GetBotReply(userMessage);

                var chatMessage = new ChatMessage
                {
                    UserMessage = userMessage,
                    BotReply = botReply,
                    Timestamp = DateTime.UtcNow
                };

                _context.ChatMessages.Add(chatMessage);
                await _context.SaveChangesAsync();

                return chatMessage;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending message: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
                throw;
            }
        }

        private async Task<string> GetBotReply(string userMessage)
        {
            if (string.IsNullOrWhiteSpace(userMessage))
            {
                return "Please type a message.";
            }

            userMessage = userMessage.ToLower();

            if (userMessage.Contains("clear chat history") || userMessage.Contains("clear") || userMessage.Contains("clear chat"))
            {
                await ClearChatHistoryAsync(); // Wait for the asynchronous operation to complete
                return "Chat history has been cleared.";
            }

            if (userMessage.Contains("hello") || userMessage.Contains("hi"))
            {
                return "Hello! How can I assist you today?";
            }

            if (userMessage.Contains("departments"))
            {
                return GetDepartments();
            }

            if (userMessage.Contains("employees"))
            {
                return GetEmployees();
            }

            if (userMessage.Contains("employee id"))
            {
                return await GetEmployeeDetailsById(userMessage);
            }

            if (userMessage.Contains("man number"))
            {
                return await GetEmployeeDetailsById(userMessage); // Assuming "man number" is the same as "employee id"
            }

            if (userMessage.Contains("employee name"))
            {
                Console.WriteLine("Employee name");
                return await GetEmployeeDetailsByName(userMessage);
            }

            if (userMessage.Contains("help") || userMessage.Contains("support"))
            {
                return "Sure, please contact our support team at support@company.com.";
            }

            if (userMessage.Contains("services"))
            {
                return "We offer a variety of services including software development, IT consulting, and project management. How can we assist you?";
            }

            if (userMessage.Contains("mission"))
            {
                return "Our mission is to deliver innovative solutions that drive business success. We aim to exceed client expectations with our dedication to quality and excellence.";
            }

            if (userMessage.Contains("founded") || userMessage.Contains("established"))
            {
                return "Our company was founded in 2010.";
            }

            if (userMessage.Contains("contact hr") || userMessage.Contains("hr department"))
            {
                return "You can contact our HR department at hr@company.com.";
            }

            if (userMessage.Contains("technical support") || userMessage.Contains("tech support"))
            {
                return "For technical support, please visit our support page at company.com/support or email techsupport@company.com.";
            }

            if (userMessage.Contains("department details"))
            {
                return await GetDepartmentDetails();
            }

            if (userMessage.Contains("employees in department"))
            {
                return await GetEmployeesInDepartment(userMessage);
            }

            return "I'm not sure how to answer that. Please try asking something else.";
        }

        private string GetDepartments()
        {
            var departments = _context.Department.Select(d => d.DepartmentName).ToList();
            return $"Here are the departments: {string.Join(", ", departments)}";
        }

        private string GetEmployees()
        {
            var employees = _context.Employee.Select(e => $"{e.FirstName} {e.LastName}").ToList();
            return $"Here are the employees: {string.Join(", ", employees)}";
        }

        private async Task<string> GetDepartmentDetails()
        {
            var departments = await _context.Department
                .Select(d => new { d.DepartmentId, d.DepartmentName })
                .ToListAsync();
            return $"Department details: {string.Join(", ", departments.Select(d => $"ID: {d.DepartmentId}, Name: {d.DepartmentName}"))}";
        }

        private async Task<string> GetEmployeesInDepartment(string userMessage)
        {
            var departmentName = userMessage.Split("employees in department ").Last().Trim();
            var department = await _context.Department
                .FirstOrDefaultAsync(d => d.DepartmentName.ToLower() == departmentName.ToLower());

            if (department == null)
            {
                return $"No department found with the name {departmentName}.";
            }

            var employees = await _context.Employee
                .Where(e => e.DepartmentId == department.DepartmentId)
                .Select(e => $"{e.FirstName} {e.LastName}")
                .ToListAsync();

            if (!employees.Any())
            {
                return $"No employees found in the {departmentName} department.";
            }

            return $"Employees in the {departmentName} department: {string.Join(", ", employees)}";
        }

        private async Task<string> GetEmployeeDetailsById(string userMessage)
        {
            var idString = new string(userMessage.Where(char.IsDigit).ToArray());

            if (string.IsNullOrEmpty(idString) || !int.TryParse(idString, out int id))
            {
                return "Please provide a valid Employee ID.";
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(e => e.EmployeeId == id || e.ManNumber == id);

            if (employee == null)
            {
                return $"No employee found with the ID or Man Number {id}.";
            }

            var department = await _context.Department
                .FirstOrDefaultAsync(d => d.DepartmentId == employee.DepartmentId);

            return $"Employee details: Name: {employee.FirstName} {employee.LastName}, Employee ID: {employee.EmployeeId}, Department: {department?.DepartmentName}";
        }

        private async Task<string> GetEmployeeDetailsByName(string userMessage)
        {
            var name = userMessage.Split("employee name ").Last().Trim().ToLower();

            var employee = await _context.Employee
                .FirstOrDefaultAsync(e => e.FirstName.ToLower() == name);

            if (employee == null)
            {
                return $"No employee found with the name {name}.";
            }

            var department = await _context.Department
                .FirstOrDefaultAsync(d => d.DepartmentId == employee.DepartmentId);

            return $"Employee details: Name: {employee.FirstName} {employee.LastName}, Employee ID: {employee.EmployeeId}, Department: {department?.DepartmentName}";
        }

        private async Task ClearChatHistoryAsync()
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync("DELETE FROM ChatMessages");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clearing chat history: {ex.Message}");
                throw;
            }
        }
    }
}