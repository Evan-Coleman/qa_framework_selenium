using GWRepository.PageObjects.PC;
using GWRepository.PageObjects.PC.NonPages;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace GWRepository.BaseObjects
{
    public class PagesBase
    {
        private BrowserBase Browser { get; set; }
        public PagesBase(BrowserBase browser)
        {
            Browser = browser;
        }

        #region PC Pages
        public PolicyChangePage PolicyChangePage
        {
            get
            {
                return new PolicyChangePage(Browser.webDriver, this);
            }
        }
        public SearchSubmissionsPage SearchSubmissionsPage
        {
            get
            {
                return new SearchSubmissionsPage(Browser.webDriver, this);
            }
        }
        public AccountFileSummaryPage AccountFileSummaryPage
        {
            get
            {
                return new AccountFileSummaryPage(Browser.webDriver, this);
            }
        }
        public TopPolicyBannerElement TopPolicyBanner
        {
            get
            {
                return new TopPolicyBannerElement(Browser.webDriver, this);
            }
        }
        public LoginPage LoginPage
        {
            get
            {
                return new LoginPage(Browser.webDriver, this);
            }
        }
        public TopMenuElement pcTopMenu
        {
            get
            {
                return new TopMenuElement(Browser.webDriver, this);
            }
        }
        public ActionsMenuElement pcActions
        {
            get
            {
                return new ActionsMenuElement(Browser.webDriver, this);
            }
        }
        public SubmissionCreateAccountPage SubmissionCreateAccountPage
        {
            get
            {
                return new SubmissionCreateAccountPage(Browser.webDriver, this);
            }
        }
        public CreateAccountPage CreateAccountPage
        {
            get
            {
                return new CreateAccountPage(Browser.webDriver, this);
            }
        }
        public MatchingContactsPage MatchingContactsPage
        {
            get
            {
                return new MatchingContactsPage(Browser.webDriver, this);
            }
        }
        public NewSubmissionsPage NewSubmissionsPage
        {
            get
            {
                return new NewSubmissionsPage(Browser.webDriver, this);
            }
        }
        public CommonTopButtonsElement CommonTopButtons
        {
            get
            {
                return new CommonTopButtonsElement(Browser.webDriver, this);
            }
        }
        public SquireEligibilityPage SquireEligibilityPage
        {
            get
            {
                return new SquireEligibilityPage(Browser.webDriver, this);
            }
        }
        public LineSelectionPage LineSelectionPage
        {
            get
            {
                return new LineSelectionPage(Browser.webDriver, this);
            }
        }
        public PolicyInfoPage PolicyInfoPage
        {
            get
            {
                return new PolicyInfoPage(Browser.webDriver, this);
            }
        }
        public LocationSquireSectionsIAndIIPage LocationSquireSectionIAndII
        {
            get
            {
                return new LocationSquireSectionsIAndIIPage(Browser.webDriver, this);
            }
        }
        public LocationInformationPage LocationInformationPage
        {
            get
            {
                return new LocationInformationPage(Browser.webDriver, this);
            }
        }
        public PropertyInformationSquireSectionsIAndIIPage PropertyInformationSquireSectionIAndII
        {
            get
            {
                return new PropertyInformationSquireSectionsIAndIIPage(Browser.webDriver, this);
            }
        }
        public PropertyDetailSquireSectionsIAndIIPage PropertyDetailSquireSectionIAndII
        {
            get
            {
                return new PropertyDetailSquireSectionsIAndIIPage(Browser.webDriver, this);
            }
        }
        public CoveragesSquireSectionsIAndIIPage CoveragesSquireSectionIAndII
        {
            get
            {
                return new CoveragesSquireSectionsIAndIIPage(Browser.webDriver, this);
            }
        }
        public RiskAnalysisPage RiskAnalysisPage
        {
            get
            {
                return new RiskAnalysisPage(Browser.webDriver, this);
            }
        }
        public SideMenuElement SideMenu
        {
            get
            {
                return new SideMenuElement(Browser.webDriver, this);
            }
        }
        public QualificationPageSquire QualificationPageSquire
        {
            get
            {
                return new QualificationPageSquire(Browser.webDriver, this);
            }
        }
        public CluePropertySectionsIAndIIPage CluePropertySectionIAndII
        {
            get
            {
                return new CluePropertySectionsIAndIIPage(Browser.webDriver, this);
            }
        }
        public PolicyMemberPage PolicyMemberPage
        {
            get
            {
                return new PolicyMemberPage(Browser.webDriver, this);
            }
        }
        public InsuranceScorePage InsuranceScorePage
        {
            get
            {
                return new InsuranceScorePage(Browser.webDriver, this);
            }
        }
        public QuotePage QuotePage
        {
            get
            {
                return new QuotePage(Browser.webDriver, this);
            }
        }
        public UWActivityPage UWActivityPage
        {
            get
            {
                return new UWActivityPage(Browser.webDriver, this);
            }
        }
        public JobCompleteScreenPage JobCompleteScreenPage
        {
            get
            {
                return new JobCompleteScreenPage(Browser.webDriver, this);
            }
        }
        public RiskApprovalDetailsPage RiskApprovalDetailsPage
        {
            get
            {
                return new RiskApprovalDetailsPage(Browser.webDriver, this);
            }
        }
        public PaymentPage PaymentPage
        {
            get
            {
                return new PaymentPage(Browser.webDriver, this);
            }
        }
        #endregion
    }
}
