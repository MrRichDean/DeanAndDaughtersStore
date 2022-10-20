using IO.Swagger.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Entities.Models;
using Store.UnitTests.Mocks;

namespace Store.UnitTests
{
    [TestClass]
    public class BooksControllerTests
    {
        [TestMethod]
        public void Get_List_Of_Books_Should_Not_Be_Null_Return_ObjectResult_And_200_StatusCode_When_Called()
        {
            // Arrange
            var context = InMemoryRecycleDb.GetData("Get_List_Of_Books");
            var sut = new BooksController(context);
            // Act
            var result = sut.GetBook("");
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ObjectResult));

            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;

            Assert.AreEqual(200, statusCode);
        }

        [TestMethod]
        public void Get_List_Of_Books_Should_Return_ObjectResult_And_400_StatusCode_With_Null_Context()
        {
            // Arrange
            var sut = new BooksController(null);
            // Act
            var result = sut.GetBook("");
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ObjectResult));

            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;

            Assert.AreEqual(400, statusCode);
        }

        [TestMethod]
        public void Get_Books_By_Id_Should_Not_Be_Null_Return_ObjectResult_And_200_StatusCode_When_Called()
        {
            // Arrange
            var context = InMemoryRecycleDb.GetData("Get_Books");
            var sut = new BooksController(context);
            // Act
            var result = sut.GetBookById(3);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ObjectResult));

            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;

            var book = (Book)objectResult.Value;
            var title = book.Title;

            Assert.AreEqual("Romeo and Juliet", title);
            Assert.AreNotEqual("Pride and Prejudice", title);
            Assert.AreEqual(200, statusCode);
        }

        [TestMethod]
        public void Get_Books_By_Id_Should_Return_ObjectResult_And_404_StatusCode_With_Id_Not_Present()
        {
            // Arrange
            var context = InMemoryRecycleDb.GetData("Get_Books");
            var sut = new BooksController(context);
            // Act
            var result = sut.GetBookById(999);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));

            var statusCodeResult = result as StatusCodeResult;


            Assert.AreEqual(404, statusCodeResult.StatusCode);
        }


        [TestMethod]
        public void Get_Books_By_Id_Should_Return_ObjectResult_And_400_StatusCode_With_Null_Context()
        {
            // Arrange
            var sut = new BooksController(null);
            // Act
            var result = sut.GetBookById(3);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ObjectResult));

            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;

            Assert.AreEqual(400, statusCode);
        }

        [TestMethod]
        public void Post_Create_Book_Should_Return_ObjectResult_And_201_StatusCode_With_Correct_Data()
        {
            // Arrange
            var context = InMemoryRecycleDb.GetData("Post_Books_201");
            var sut = new BooksController(context);
            var newBook = new Book { Author = "R.A.Dean", Id = null, Price = 0.99, Title = "Don't forget about null" };
            // Act
            var result = sut.CreateBook(newBook);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ObjectResult));

            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;

            Assert.AreEqual(201, statusCode);
        }

        [TestMethod]
        public void Post_Create_Book_Should_Return_ObjectResult_And_400_StatusCode_When_Passing_Id()
        {
            // Arrange
            var context = InMemoryRecycleDb.GetData("Post_Books_400");
            var sut = new BooksController(context);
            var newBook = new Book { Author = "R.A.Dean", Id = 1, Price = 0.99, Title = "Forgot about null" };
            // Act
            var result = sut.CreateBook(newBook);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ObjectResult));

            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;

            Assert.AreEqual(400, statusCode);
        }

        [TestMethod]
        public void Delete_Book_Should_Return_ObjectResult_And_200_StatusCode_With_Correct_Data()
        {
            // Arrange
            var context = InMemoryRecycleDb.GetData("Delete_Books_200");
            var sut = new BooksController(context);
       
            // Act
            var result = sut.DeleteBookById(1);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            
            var statusCodeResult = (StatusCodeResult) result;

            Assert.AreEqual(200, statusCodeResult.StatusCode);
        }

        [TestMethod]
        public void Delete_Book_Should_Return_ObjectResult_And_404_StatusCode_With_Unknown_Id()
        {
            // Arrange
            var context = InMemoryRecycleDb.GetData("Delete_Books_404");
            var sut = new BooksController(context);

            // Act
            var result = sut.DeleteBookById(999);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            
            var statusCodeResult = (StatusCodeResult)result;

            Assert.AreEqual(404, statusCodeResult.StatusCode);
        }

        [TestMethod]
        public void Delete_Book_Should_Return_ObjectResult_And_400_StatusCode_With_Null_Context()
        {
            // Arrange
            var sut = new BooksController(null);

            // Act
            var result = sut.DeleteBookById(1);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ObjectResult));

            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;

            Assert.AreEqual(400, statusCode);
        }

        [TestMethod]
        public void Put_Update_Book_Should_Return_ObjectResult_And_200_StatusCode_With_Correct_Data()
        {
            // Arrange
            var context = InMemoryRecycleDb.GetData("Put_Books_201");
            var sut = new BooksController(context);
            var updateBook = new Book { Author = "R.A.Dean", Id = 3, Price = 9.99, Title = "Gnomeo and Juliet" };
            // Act
            var result = sut.UpdateBookById(updateBook,3);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));

            var statusCodeResult = (StatusCodeResult)result;

            Assert.AreEqual(200, statusCodeResult.StatusCode);
        }

        [TestMethod]
        public void Put_Update_Should_Return_ObjectResult_And_404_StatusCode_When_Passing_Unknown_Id()
        {
            // Arrange
            var context = InMemoryRecycleDb.GetData("Put_Books_404");
            var sut = new BooksController(context);
            var updateBook = new Book { Author = "R.A.Dean", Id = 999, Price = 9.99, Title = "Gnomeo and Juliet" };
            // Act
            var result = sut.UpdateBookById(updateBook, 999);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));

            var statusCodeResult = (StatusCodeResult)result;

            Assert.AreEqual(404, statusCodeResult.StatusCode);
        }

        [TestMethod]
        public void Put_Update_Book_Should_Return_ObjectResult_And_400_StatusCode_When_Id_In_Body_Differs_From_Id() 
        {
            // Arrange
            var context = InMemoryRecycleDb.GetData("Put_Books_400");
            var sut = new BooksController(context);
            var updateBook = new Book { Author = "R.A.Dean", Id = 3, Price = 9.99, Title = "Gnomeo and Juliet" };
            // Act
            var result = sut.UpdateBookById(updateBook, 999);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ObjectResult));

            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;

            Assert.AreEqual(400, statusCode);
        }
    }
}