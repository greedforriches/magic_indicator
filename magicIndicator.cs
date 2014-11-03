#region Using declarations
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;
using NinjaTrader.Cbi;
using NinjaTrader.Data;
using NinjaTrader.Gui.Chart;
#endregion

namespace NinjaTrader.Indicator
{
/// <summary>
	/// So if you use this indicator and it does not make money for you or you loose your house thats all on you.
	/// You are free to edit this and so on but don't expect anything from it. Its a tool to help you nothing more. You deside when to enter and exit the market
/// </summary>
	[Description("Poor Richsob's magic trading indicator.")]
    public class PoorRichSOB : Indicator
    {
        #region Variables
        // Wizard generated variables
            private int myInput0 = 1; // Default setting for MyInput0
        // User defined variables (add any user defined variables below)
        #endregion

        protected override void Initialize()
        {
        }
        protected override void OnBarUpdate()
        {
			
        }

        #region Properties
        [Browsable(false)]	// this line prevents the data series from being displayed in the indicator properties dialog, do not remove
        [XmlIgnore()]		// this line ensures that the indicator can be saved/recovered as part of a chart template, do not remove
        public DataSeries Plot0
        {
            get { return Values[0]; }
        }

        [Description("")]
        [GridCategory("Parameters")]
        public int MyInput0
        {
            get { return myInput0; }
            set { myInput0 = Math.Max(1, value); }
        }
        #endregion
    }
}

#region NinjaScript generated code. Neither change nor remove.
// This namespace holds all indicators and is required. Do not change it.
namespace NinjaTrader.Indicator
{
    public partial class Indicator : IndicatorBase
    {
        private PoorRichSOB[] cachePoorRichSOB = null;

        private static PoorRichSOB checkPoorRichSOB = new PoorRichSOB();

        /// <summary>
        /// Poor Richsob's magic trading indicator.
        /// </summary>
        /// <returns></returns>
        public PoorRichSOB PoorRichSOB(int myInput0)
        {
            return PoorRichSOB(Input, myInput0);
        }

        /// <summary>
        /// Poor Richsob's magic trading indicator.
        /// </summary>
        /// <returns></returns>
        public PoorRichSOB PoorRichSOB(Data.IDataSeries input, int myInput0)
        {
            if (cachePoorRichSOB != null)
                for (int idx = 0; idx < cachePoorRichSOB.Length; idx++)
                    if (cachePoorRichSOB[idx].MyInput0 == myInput0 && cachePoorRichSOB[idx].EqualsInput(input))
                        return cachePoorRichSOB[idx];

            lock (checkPoorRichSOB)
            {
                checkPoorRichSOB.MyInput0 = myInput0;
                myInput0 = checkPoorRichSOB.MyInput0;

                if (cachePoorRichSOB != null)
                    for (int idx = 0; idx < cachePoorRichSOB.Length; idx++)
                        if (cachePoorRichSOB[idx].MyInput0 == myInput0 && cachePoorRichSOB[idx].EqualsInput(input))
                            return cachePoorRichSOB[idx];

                PoorRichSOB indicator = new PoorRichSOB();
                indicator.BarsRequired = BarsRequired;
                indicator.CalculateOnBarClose = CalculateOnBarClose;
#if NT7
                indicator.ForceMaximumBarsLookBack256 = ForceMaximumBarsLookBack256;
                indicator.MaximumBarsLookBack = MaximumBarsLookBack;
#endif
                indicator.Input = input;
                indicator.MyInput0 = myInput0;
                Indicators.Add(indicator);
                indicator.SetUp();

                PoorRichSOB[] tmp = new PoorRichSOB[cachePoorRichSOB == null ? 1 : cachePoorRichSOB.Length + 1];
                if (cachePoorRichSOB != null)
                    cachePoorRichSOB.CopyTo(tmp, 0);
                tmp[tmp.Length - 1] = indicator;
                cachePoorRichSOB = tmp;
                return indicator;
            }
        }
    }
}

// This namespace holds all market analyzer column definitions and is required. Do not change it.
namespace NinjaTrader.MarketAnalyzer
{
    public partial class Column : ColumnBase
    {
        /// <summary>
        /// Poor Richsob's magic trading indicator.
        /// </summary>
        /// <returns></returns>
        [Gui.Design.WizardCondition("Indicator")]
        public Indicator.PoorRichSOB PoorRichSOB(int myInput0)
        {
            return _indicator.PoorRichSOB(Input, myInput0);
        }

        /// <summary>
        /// Poor Richsob's magic trading indicator.
        /// </summary>
        /// <returns></returns>
        public Indicator.PoorRichSOB PoorRichSOB(Data.IDataSeries input, int myInput0)
        {
            return _indicator.PoorRichSOB(input, myInput0);
        }
    }
}

// This namespace holds all strategies and is required. Do not change it.
namespace NinjaTrader.Strategy
{
    public partial class Strategy : StrategyBase
    {
        /// <summary>
        /// Poor Richsob's magic trading indicator.
        /// </summary>
        /// <returns></returns>
        [Gui.Design.WizardCondition("Indicator")]
        public Indicator.PoorRichSOB PoorRichSOB(int myInput0)
        {
            return _indicator.PoorRichSOB(Input, myInput0);
        }

        /// <summary>
        /// Poor Richsob's magic trading indicator.
        /// </summary>
        /// <returns></returns>
        public Indicator.PoorRichSOB PoorRichSOB(Data.IDataSeries input, int myInput0)
        {
            if (InInitialize && input == null)
                throw new ArgumentException("You only can access an indicator with the default input/bar series from within the 'Initialize()' method");

            return _indicator.PoorRichSOB(input, myInput0);
        }
    }
}
#endregion
