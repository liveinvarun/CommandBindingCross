
using System;
using UIKit;
using CoreGraphics;
using System.Text.RegularExpressions;
using Foundation;
using System.ComponentModel;
using CoreAnimation;
namespace SampleApp
{
    [Register("FloatingTextField"), DesignTimeVisible(true)]
    public class FloatingTextField : UITextField
    {
        private UILabel _floatingLabel;

        [DisplayName("Label Color"), Export("FloatingLabelTextColor"), Browsable(true)]
        public UIColor FloatingLabelTextColor { get; set; } = UIColor.Gray;

        [DisplayName("Label Active Color"), Export("FloatingLabelActiveTextColor"), Browsable(true)]
        public UIColor FloatingLabelActiveTextColor { get; set; } = UIColor.Blue;


        [DisplayName("IsUnderLined"), Export("IsUnderLined"), Browsable(true)]
        public bool IsUnderLined { get; set; } = false;

        public UIFont FloatingLabelFont
        {
            get { return _floatingLabel.Font; }
            set { _floatingLabel.Font = value; }
        }

        public FloatingTextField(CGRect frame)
                    : base(frame)
        {
            InitializeLabel();
        }

        public FloatingTextField(IntPtr handle)
                    : base(handle)
        {

        }

        public override void AwakeFromNib() => InitializeLabel();

        private void InitializeLabel()
        {
            //FloatingLabelActiveTextColor = UIColor.FromRGBA(63f, 63f, 65f, 0f);
            FloatingLabelActiveTextColor = UIColor.Gray;
            //FloatingLabelTextColor = UIColor.FromRGBA(102f, 139f, 175f, 0f);
            FloatingLabelTextColor = UIColor.Gray;

            _floatingLabel = new UILabel
            {
                Alpha = 0.0f,
                Font = UIFont.SystemFontOfSize(12),
            };

            AddSubview(_floatingLabel);

            Placeholder = Placeholder; // sets up label frame

            ApplyLanguageSettings();

            this.ShouldReturn = (textField) =>
            {
                this.ResignFirstResponder();
                return true;
            };
            IsUnderLined = true;
        }

        public override string Placeholder
        {
            get { return base.Placeholder; }
            set
            {
                base.Placeholder = value;

                _floatingLabel.Text = value;
                _floatingLabel.SizeToFit();
                if (IsLTRLanguage)
                {
                    _floatingLabel.Frame =
                          new CGRect(
                              0, _floatingLabel.Font.LineHeight,
                              _floatingLabel.Frame.Size.Width, _floatingLabel.Frame.Size.Height);
                }
                else
                {
                    _floatingLabel.Frame =
                        new CGRect(
                                          this.Frame.Width, _floatingLabel.Font.LineHeight,
                            _floatingLabel.Frame.Size.Width, _floatingLabel.Frame.Size.Height);
                }
            }
        }

        public override CGRect TextRect(CGRect forBounds)
        {
            if (_floatingLabel == null)
                return base.TextRect(forBounds);

            return InsetRect(base.TextRect(forBounds), new UIEdgeInsets(_floatingLabel.Font.LineHeight, 0, 0, 0));
        }

        public override CGRect EditingRect(CGRect forBounds)
        {
            if (_floatingLabel == null)
                return base.EditingRect(forBounds);

            return InsetRect(base.EditingRect(forBounds), new UIEdgeInsets(_floatingLabel.Font.LineHeight, 0, 0, 0));
        }

        public override CGRect ClearButtonRect(CGRect forBounds)
        {
            var rect = base.ClearButtonRect(forBounds);

            if (_floatingLabel == null)
                return rect;

            return new CGRect(
                rect.X, rect.Y + _floatingLabel.Font.LineHeight / 2.0f,
                rect.Size.Width, rect.Size.Height);
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            Action updateLabel = () =>
            {
                //_floatingLabel.TextColor = UIColor.FromRGBA(63f, 63f, 65f, 0f);

                _floatingLabel.TextColor = UIColor.Blue;
                if (!string.IsNullOrEmpty(Text))
                {
                    _floatingLabel.Alpha = 1.0f;
                    if (IsLTRLanguage)
                    {
                        _floatingLabel.Frame =
                          new CGRect(
                              _floatingLabel.Frame.Location.X,
                              2.2f,
                              _floatingLabel.Frame.Size.Width,
                              _floatingLabel.Frame.Size.Height);
                    }
                    else
                    {

                        _floatingLabel.TextAlignment = UITextAlignment.Right;
                        _floatingLabel.Frame =
                      new CGRect(
                                            this.Frame.Width - this._floatingLabel.AttributedText.Size.Width,//asdfasd
                          2.2f,
                          _floatingLabel.Frame.Size.Width,
                          _floatingLabel.Frame.Size.Height);
                        _floatingLabel.SizeToFit();
                    }
                }
                else
                {
                    _floatingLabel.Alpha = 0.0f;

                    if (IsLTRLanguage)
                    {
                        _floatingLabel.Frame =
                           new CGRect(
                               _floatingLabel.Frame.Location.X,
                               _floatingLabel.Font.LineHeight,
                               _floatingLabel.Frame.Size.Width,
                               _floatingLabel.Frame.Size.Height);
                    }
                    else
                    {
                        _floatingLabel.TextAlignment = UITextAlignment.Right;
                        _floatingLabel.Frame =
                              new CGRect(
                                              this.Frame.Width - this._floatingLabel.AttributedText.Size.Width,
                                  _floatingLabel.Font.LineHeight,
                                  _floatingLabel.Frame.Size.Width,
                         _floatingLabel.Frame.Size.Height);
                    }
                }
            };

            if (IsFirstResponder)
            {
                //_floatingLabel.TextColor = UIColor.FromRGBA(63f, 63f, 65f, 0f);
                _floatingLabel.TextColor = UIColor.Black;
                //_floatingLabel.TextColor = UIColor.Orange;
                var shouldFloat = !string.IsNullOrEmpty(Text);
                var isFloating = _floatingLabel.Alpha == 1f;

                if (shouldFloat == isFloating)
                {
                    updateLabel();
                }
                else
                {
                    Animate(
                        0.3f, 0.0f,
                        UIViewAnimationOptions.BeginFromCurrentState
                        | UIViewAnimationOptions.CurveEaseOut,
                        () => updateLabel(),
                        () => { });
                }
            }
            else
            {
                _floatingLabel.TextColor = FloatingLabelTextColor;
                //_floatingLabel.TextColor = UIColor.Orange;

                updateLabel();
            }

            if (IsUnderLined)
            {
                CALayer border = new CALayer();
                float borderWidth = 1;
                border.BorderWidth = borderWidth;
                this.Layer.AddSublayer(border);
                this.Layer.MasksToBounds = true;
                border.BorderColor = UIColor.Black.CGColor;
                //UIColor.FromRGBA(63f, 63f, 65f, 0f).CGColor;
                //     border.BorderColor = Helpers.ToUIColor(Constants.Colors.TextFieldLineColor).CGColor;

                if (IsLTRLanguage)
                {
                    border.Frame = new CGRect(0, this.Frame.Size.Height - borderWidth, this.Frame.Size.Width, this.Frame.Size.Height);
                }
                else
                {
                    border.Frame = new CGRect(0, this.Frame.Size.Height - borderWidth, this.Frame.Size.Width, this.Frame.Size.Height);

                }



            }
        }

        void AddLine()
        {
            var border = new CoreAnimation.CALayer();
            float width = 1f;
            border.BorderColor = UIColor.LightGray.CGColor;
            border.Frame = new CGRect(0, this.Frame.Size.Height - width, this.Frame.Size.Width, this.Frame.Size.Height);
            border.BorderWidth = width;
            this.Layer.AddSublayer(border);
            this.Layer.MasksToBounds = true;
        }

        private CGRect InsetRect(CGRect rect, UIEdgeInsets insets)
        {
            if (IsLTRLanguage)
            {
                return
                    new CGRect(
                        rect.X + insets.Left,
                        rect.Y + insets.Top,
                        rect.Width - insets.Left - insets.Right,
                        rect.Height - insets.Top - insets.Bottom);
            }
            else
            {
                return
                    new CGRect(rect.X + insets.Right,//asdfsdfa
                        rect.Y + insets.Top,
                        rect.Width - insets.Left - insets.Right,
                        rect.Height - insets.Top - insets.Bottom);
            }
        }

        /// <summary>
        /// Applies the language settings.
        /// </summary>
        void ApplyLanguageSettings()
        {
            if (IsLTRLanguage)
            {
                this.TextAlignment = UITextAlignment.Left;
                _floatingLabel.TextAlignment = UITextAlignment.Left;

            }
            else
            {
                this.TextAlignment = UITextAlignment.Right;
                _floatingLabel.TextAlignment = UITextAlignment.Right;

            }
        }

        public bool IsLTRLanguage
        {
            get
            {
                return (UIApplication.SharedApplication.UserInterfaceLayoutDirection == UIUserInterfaceLayoutDirection.LeftToRight) ? true : false;
            }
        }

        public override bool CanPerform(ObjCRuntime.Selector action, NSObject withSender)
        {
            return false;
        }
    }

}
