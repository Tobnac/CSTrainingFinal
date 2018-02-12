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

        public ILoadingSequence Process(List<IElement> elements)
        {
            List<IElement> unLoadedElements = new List<IElement>(elements);
            var haveBeenLoaded = new LoadingSequence();
            var loadedRecourses = new List<IResource>();
            var canBeLoaded = new List<IElement>();
            var currentStep = new List<IElement>();

            do {
                canBeLoaded = GetCanBeLoaded();//last checkpoint!<-----------------
            }
            while (canBeLoaded.Count != 0) ;

            haveBeenLoaded.NotLoadedElements = unLoadedElements;
            return haveBeenLoaded;
        }

        private List<IElement> GetCanBeLoaded()
        {
            return null; //todo
        }
    }

    [TestFixture]
    class LoadingProcessorTest
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
            Assert.AreEqual(LoadingProcessorAcceptanceResult_LoadingSelfProvideStrategy_Disallowed_LoadingQuantityStrategy_Multi, 
                new LoadingProcessor().Process(acceptanceInput));
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
            Assert.AreEqual(true, false);
            //todo: needs another spesific acceptance test!
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
            Assert.AreEqual(new LoadingSequence(disalowed_multi_loadingSequence, new List<IElement>() { GB }),
                new LoadingProcessor().Process(acceptanceInput));

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
            Assert.AreEqual(true, false);
            //todo: needs another spesific acceptance test!
        }
    }
}
