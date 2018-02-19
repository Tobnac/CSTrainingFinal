using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFinal
{
    class LoadingProcessor : ILoadingProcessor
    {
        public ILoadingQuantityStrategy QuantityStrategy { get; set; }
        public ILoadingSelfProvideStrategy SelfProvideStragegy { get; set; }

        private List<IResource> availableResoucres;

        public LoadingProcessor(ILoadingQuantityStrategy qs, ILoadingSelfProvideStrategy sps)
        {
            this.QuantityStrategy = qs;
            this.SelfProvideStragegy = sps;
        }

        public ILoadingSequence Process(List<IElement> elements)
        {
            var unloadedElements = new List<IElement>(elements);
            var resultSequence = new LoadingSequence();
            this.availableResoucres = new List<IResource>();
            var loadableElements = new List<IElement>();

            do
            {
                loadableElements = this.GetLoadableElements(unloadedElements);
                this.AddElementsToResultSequence(loadableElements, resultSequence, unloadedElements);
            }
            while (loadableElements.Count != 0);

            // done. now save all not-loadable elements
            resultSequence.NotLoadedElements = unloadedElements;

            return resultSequence;
        }

        private void AddElementsToResultSequence(List<IElement> loadableElements, LoadingSequence resultSequence, List<IElement> unloadedElements)
        {
            if (loadableElements.Count == 0) return;

            // use QuantityStrategy to either
            // - load all of the elements in one step
            // - or load them one by one in multiple steps

            // add their resources to the availables ones
            var loaded = this.QuantityStrategy.ResolveLoadingSequence(loadableElements, resultSequence);

            foreach (var ele in loaded)
            {
                this.availableResoucres.AddRange(ele.Provisions);
                unloadedElements.Remove(ele);
            }
        }

        private List<IElement> GetLoadableElements(List<IElement> unloadedElements)
        {
            var result = new List<IElement>();

            foreach (var ele in unloadedElements)
            {
                var resources = this.availableResoucres;

                // based on SelfProvideStrat:
                // - add the resources the current element provides to the currently available resources
                // - or not 
                resources = this.SelfProvideStragegy.ExpandAvailableResources(resources, ele);

                if (this.CanElementBeLoaded(ele, resources))
                {
                    result.Add(ele);
                }
            }

            return result;
        }

        private bool CanElementBeLoaded(IElement element, List<IResource> availableResources)
        {
            //return element.Requirements.Intersect(availableResoucres).Count() == element.Requirements.Count();
            return element.Requirements.All(x => availableResoucres.Contains(x));
        }
    }





















    [TestFixture]
    public class LoadingProcessorTest
    {
        private static IElement AS = new Element("AS", Helper.ConvertToResourceList("X", "B"), Helper.ConvertToResourceList("Y"));
        private static IElement GB = new Element("GB", Helper.ConvertToResourceList("X", "Y", "D"), Helper.ConvertToResourceList("R"));
        private static IElement M5 = new Element("M5", Helper.ConvertToResourceList("B"), Helper.ConvertToResourceList("R"));
        private static IElement MR = new Element("MR", Helper.ConvertToResourceList(), Helper.ConvertToResourceList("A", "B"));
        private static IElement M2 = new Element("M2", Helper.ConvertToResourceList("B"), Helper.ConvertToResourceList("X"));
        private static IElement NN = new Element("NN", Helper.ConvertToResourceList("R"), Helper.ConvertToResourceList("F"));
        private static IElement AFEF = new Element("AFEF", Helper.ConvertToResourceList("A", "B", "X", "Y", "R"), Helper.ConvertToResourceList());
        private static IElement XA = new Element("XA", Helper.ConvertToResourceList(), Helper.ConvertToResourceList("B"));
        private static IElement XB = new Element("XB", Helper.ConvertToResourceList(), Helper.ConvertToResourceList("R"));

        private static List<IElement> acceptanceInput = new List<IElement>()
        {
            AS, GB, M5, MR, M2, NN, AFEF, XA, XB
        };

        private static List<List<IElement>> disalowed_multi_loadingSequence = new List<List<IElement>>()
        {
            new List<IElement>(){ MR, XA, XB },
            new List<IElement>(){ M5, M2, NN },
            new List<IElement>(){ AS },
            new List<IElement>(){ AFEF }
        };

        private static LoadingSequence LoadingProcessorAcceptanceResult_LoadingSelfProvideStrategy_Disallowed_LoadingQuantityStrategy_Multi =
            new LoadingSequence(disalowed_multi_loadingSequence, new List<IElement>() { GB });

        [Test]
        public void LoadingProcessorAcceptanceTest_LoadingSelfProvideStrategy_Disallowed_LoadingQuantityStrategy_Multi()
        {
            var expect = LoadingProcessorAcceptanceResult_LoadingSelfProvideStrategy_Disallowed_LoadingQuantityStrategy_Multi;
            var actual = new LoadingProcessor(new LQS_Multi(), new LSPS_Disallowed()).Process(acceptanceInput);

            Assert.AreEqual(expect, actual);

            {
                // 1: A B R
                // 2: X F
                // 3: Y
                // 4:
                // 5:
                // 6:
                // Elementen: 
                //      1: XA XB MR
                //      2: M5 M2 NN
                //      3: AS  
                //      4: AFEF
                //      5:
                //      6:not Loaded: GB
                //
            }
        }

        [Test]
        public void LoadingProcessorAcceptanceTest_LoadingSelfProvideStrategy_Allowed_LoadingQuantityStrategy_Multi()
        {
            Assert.AreEqual(true, true);
            //todo: needs another specific acceptance test!
        }

        private static List<List<IElement>> disalowed_single_loadingSequence = new List<List<IElement>>()
        {
            new List<IElement>(){ MR },
            new List<IElement>(){ M5 },
            new List<IElement>(){ M2 },
            new List<IElement>(){ AS },
            new List<IElement>(){ NN },
            new List<IElement>(){ AFEF },
            new List<IElement>(){ XA },
            new List<IElement>(){ XB }
        };
        [Test]
        public void LoadingProcessorAcceptanceTest_LoadingSelfProvideStrategy_Disallowed_LoadingQuantityStrategy_Single()
        {
            var expect = new LoadingSequence(disalowed_single_loadingSequence, new List<IElement>() { GB });
            var actual = new LoadingProcessor(new LQS_Single(), new LSPS_Disallowed()).Process(acceptanceInput);

            Assert.AreEqual(expect, actual);

            {
                // 1: A B
                // 2: R
                // 3: X
                // 4: Y
                // 5: F
                // 6:
                // ...
                // Elementen: 
                //      1: MR
                //      2: M5
                //      3: M2
                //      4: AS
                //      5: NN
                //      6: AFEF
                //      7: XA
                //      8: XB
                //      9: 
                //     10:not Loaded: GB
                //
            }
        }

        [Test]
        public void LoadingProcessorAcceptanceTest_LoadingSelfProvideStrategy_Allowed_LoadingQuantityStrategy_Single()
        {
            Assert.AreEqual(true, true);
            //todo: needs another specific acceptance test!
        }
    }
}
