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
    public class magicIndicator : Indicator
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
			if(CrossAbove(SMA(5), SMA(25), 1))
			{
				DrawArrowUp("GOShort" + CurrentBar, true, 0, Low[0] - TickSize, Color.Red);
			}
			else if (CrossBelow(SMA(5), SMA(25), 1))
			{
				DrawArrowDown("GOLong" + CurrentBar, true, 0, High[0] + TickSize, Color.Blue);
			}
			
			if(SMA(5)[0] > Close[0])
			{
				DrawDot("BellowSMA" + CurrentBar,true, 0,Low[0] - TickSize, Color.Yellow);
			}
			else if(SMA(5)[0] < Close[0])
			{
				DrawDot("AboveSMA" + CurrentBar,true, 0,High[0] + TickSize, Color.Green);
			}
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
        private magicIndicator[] cachemagicIndicator = null;

        private static magicIndicator checkmagicIndicator = new magicIndicator();

        /// <summary>
        /// Poor Richsob's magic trading indicator.
        /// </summary>
        /// <returns></returns>
        public magicIndicator magicIndicator(int myInput0)
        {
            return magicIndicator(Input, myInput0);
        }

        /// <summary>
        /// Poor Richsob's magic trading indicator.
        /// </summary>
        /// <returns></returns>
        public magicIndicator magicIndicator(Data.IDataSeries input, int myInput0)
        {
            if (cachemagicIndicator != null)
                for (int idx = 0; idx < cachemagicIndicator.Length; idx++)
                    if (cachemagicIndicator[idx].MyInput0 == myInput0 && cachemagicIndicator[idx].EqualsInput(input))
                        return cachemagicIndicator[idx];

            lock (checkmagicIndicator)
            {
                checkmagicIndicator.MyInput0 = myInput0;
                myInput0 = checkmagicIndicator.MyInput0;

                if (cachemagicIndicator != null)
                    for (int idx = 0; idx < cachemagicIndicator.Length; idx++)
                        if (cachemagicIndicator[idx].MyInput0 == myInput0 && cachemagicIndicator[idx].EqualsInput(input))
                            return cachemagicIndicator[idx];

                magicIndicator indicator = new magicIndicator();
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

                magicIndicator[] tmp = new magicIndicator[cachemagicIndicator == null ? 1 : cachemagicIndicator.Length + 1];
                if (cachemagicIndicator != null)
                    cachemagicIndicator.CopyTo(tmp, 0);
                tmp[tmp.Length - 1] = indicator;
                cachemagicIndicator = tmp;
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
        public Indicator.magicIndicator magicIndicator(int myInput0)
        {
            return _indicator.magicIndicator(Input, myInput0);
        }

        /// <summary>
        /// Poor Richsob's magic trading indicator.
        /// </summary>
        /// <returns></returns>
        public Indicator.magicIndicator magicIndicator(Data.IDataSeries input, int myInput0)
        {
            return _indicator.magicIndicator(input, myInput0);
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
        public Indicator.magicIndicator magicIndicator(int myInput0)
        {
            return _indicator.magicIndicator(Input, myInput0);
        }

        /// <summary>
        /// Poor Richsob's magic trading indicator.
        /// </summary>
        /// <returns></returns>
        public Indicator.magicIndicator magicIndicator(Data.IDataSeries input, int myInput0)
        {
            if (InInitialize && input == null)
                throw new ArgumentException("You only can access an indicator with the default input/bar series from within the 'Initialize()' method");

            return _indicator.magicIndicator(input, myInput0);
        }
    }
}
#endregion
