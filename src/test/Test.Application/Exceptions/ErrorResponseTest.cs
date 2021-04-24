using Application.Exceptions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Xunit;

namespace Test.Application.Exceptions
{
    public class ErrorManagerTest
    {
        private const string Message = "The widget has unavoidably blooped out.";
        private readonly ValidationResult Error1 = new ValidationResult("error 1");
        private readonly ValidationResult Error2 = new ValidationResult("error 2");
        private readonly List<ValidationResult> ValidationResults = new List<ValidationResult>();

        public ErrorManagerTest()
        {
            ValidationResults.Add(Error1);
            ValidationResults.Add(Error2);
        }
        /*
        [Fact]
        public void Should_create_empty_error()
        {
            ModelValidationException ex = new ModelValidationException(Message, ValidationResults);

            // Sanity check: Make sure custom properties are set before serialization
            Assert.Equal(Message, ex.Message);
            Assert.Equal(2, ex.ValidationErrors.Count);
            Assert.Equal(Error1, ex.ValidationErrors[0]);
            Assert.Equal(Error2, ex.ValidationErrors[1]);

            // Save the full ToString() value, including the exception message and stack trace.
            string exceptionToString = ex.ToString();

            // Round-trip the exception: Serialize and de-serialize with a BinaryFormatter
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                // "Save" object state
                bf.Serialize(ms, ex);

                // Re-use the same stream for de-serialization
                ms.Seek(0, 0);

                // Replace the original exception with de-serialized one
                ex = (ModelValidationException)bf.Deserialize(ms);
            }

            // Make sure custom properties are preserved after serialization
            Assert.Equal(Message, ex.Message);
            Assert.Equal(2, ex.ValidationErrors.Count);
            Assert.Equal(Error1, ex.ValidationErrors[0]);
            Assert.Equal(Error2, ex.ValidationErrors[1]);

            // Double-check that the exception message and stack trace (owned by the base Exception) are preserved
            Assert.Equal(exceptionToString, ex.ToString());
        }
        }*/
    }
}
