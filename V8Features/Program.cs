using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using UsingDeclarations;
using V8Features;
using V8Features.Models;

namespace V8Features
{
    public class Program
    {
        static async Task Main(string[] args)
        {

            #region PropertyPatternMatching && Indexing Array features
            InMemoryDb db = new InMemoryDb(); // BuildBlogs method has Indexing array C#8.0 new features
            var Shareable = db.blogPosts.Where(post => post.isShareAble()).ToList(); // isShareAble method does propertyPatternMatching 
            foreach (var share in Shareable)
            {
                Console.WriteLine("Blog shareable publicly {0}", share.Title);
            } 
            #endregion

            #region SwitchExperssion
            IShape shape1 = new Circle(20);
            SwitchExpressionSample.GetInfoShape(shape1);
            IShape shape2 = new Traingle(10, 20, 30);
            SwitchExpressionSample.GetInfoShape(shape2);
            IShape shape3 = new Rectangle(10, 10);
            var shape = SwitchExpressionSample.GetInfoShape(shape3);
            Console.WriteLine($"SwitchExperssion gives shape ::: {shape}");
            #endregion

            #region SwitchTupleExpression
            Color color1 = Color.Blue;
            Color color2 = Color.Red;
            var colorTheme = SwitchExpressionTuple.GetColorTheme(color1, color2);
            Console.WriteLine($"SwitchTupleExpression gives color Theme ::: {colorTheme}");
            #endregion

            #region readonly && NullCoalescing 
            //readonly properties are immutable they cannot be reassigned once after object creation
            //db.Salary = 500; will give compile time error 
            var entity = db.booksRepository.GetByID(1); // Null coalescing
            entity ??= db.BuildNewEntity();
            #endregion

            #region DefaultInterfaceMethods
            int bookID = 1;
            IDefaultBook[] books = db.booksRepository.GetAll().ToArray();
            Book book1 = books[0].rateBook(bookID); // C#8.0 defaultImplementation rateBook method of interface
            Console.WriteLine($"Book{book1.Id} has rating :::{book1.Rating}");
            #endregion

            #region AsyncStreaming 
            AsyncStream stream = new AsyncStream();
            stream.DisplayOrders();
            await stream.DisplayOrderAsync(); 
            #endregion

            #region UsingDeclarations
            using (var resource1 = new DisposableResource()) //using statement need to be used which had scope defined 
            {
                Console.WriteLine($"Using resource: {resource1.Value}");
            }
            using var resource2 = new DisposableResource();  //C#8.0 scope is entire block till main method is executed
            Console.WriteLine($"Using resource: {resource2.Value}");
            #endregion

            #region LocalFunction
            LocalFunction local = new LocalFunction();
            local.Run(); // Run Method has 2 localFunctions which are static
            #endregion

            #region Structwithreadonly
            Axis structaxix = new Axis();
            structaxix.ToString(); 
            #endregion
        }
    }
    }


