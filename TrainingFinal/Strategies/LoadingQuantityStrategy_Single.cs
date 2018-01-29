using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    class LQS_Single : ILoadingQuantityStrategy
    {
        public ILoadingSelfProvideStrategy SelfProvideStrategy { get; set; }
        public List<IElement> ElementList { get; set; }

        private List<IResource> availabelResources = new List<IResource>();

        public ILoadingSequence ResolveLoadingSequence(List<IElement> elements)
        {
            var result = new LoadingSequence();
            var didNothing = true;

            while (elements.Count > 0)
            {
                foreach (var element in elements)
                {
                    if (this.SelfProvideStrategy.CanBeLoaded(element, availabelResources))
                    {
                        result.AddLoadingStep(element);
                        elements.Remove(element);
                        didNothing = false;
                        break;
                    }
                }

                // none of the remaining elements could be loaded
                // the specified element cannot fully be loaded
                if (didNothing)
                {
                    Console.WriteLine("Specified elements could not be fully loaded with the selected configuration.");
                    break;
                }
            }

            return result;
        }
    }

    [TestFixture]
    class LQS_Single_Tests
    {
        private static LQS_Single tester = new LQS_Single()
        {
            SelfProvideStrategy = new LSPS_Disallowed()
        };

        [Test]
        public static void AcceeptanceTest_LQSS()
        {
            //var input = new List<IElement>()
            //{
            //    new Element("A", Helper.ConvertToResourceList(), Helper.ConvertToResourceList("A")),
            //    new Element("A", Helper.ConvertToResourceList("A"), Helper.ConvertToResourceList())
            //};

            //var expection = new LoadingSequence();
            //expection.AddLoadingStep(input[0]);
            //expection.AddLoadingStep(input[1]);

            //Assert.Equals(expection, tester.ResolveLoadingSequence(input));
        }

    }
}
