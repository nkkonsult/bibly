﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:2.0.0.0
//      Reqnroll Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Bibly.ValidationTest.Features
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class BooksManagementFeature : object, Xunit.IClassFixture<BooksManagementFeature.FixtureData>, Xunit.IAsyncLifetime
    {
        
        private global::Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private static global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Books management", null, global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "Books.Feature"
#line hidden
        
        public BooksManagementFeature(BooksManagementFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
        }
        
        public static async System.Threading.Tasks.Task FeatureSetupAsync()
        {
        }
        
        public static async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
        }
        
        public async System.Threading.Tasks.Task TestInitializeAsync()
        {
            testRunner = global::Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(featureHint: featureInfo);
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Equals(featureInfo) == false)))
            {
                await testRunner.OnFeatureEndAsync();
            }
            if ((testRunner.FeatureContext == null))
            {
                await testRunner.OnFeatureStartAsync(featureInfo);
            }
        }
        
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
            global::Reqnroll.TestRunnerManager.ReleaseTestRunner(testRunner);
        }
        
        public void ScenarioInitialize(global::Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        public virtual async System.Threading.Tasks.Task FeatureBackgroundAsync()
        {
#line 3
#line hidden
            global::Reqnroll.Table table1 = new global::Reqnroll.Table(new string[] {
                        "Id",
                        "First Name",
                        "Last Name",
                        "Birth Date"});
            table1.AddRow(new string[] {
                        "15",
                        "J.R.R.",
                        "Tolkien",
                        "1892-01-03"});
            table1.AddRow(new string[] {
                        "16",
                        "George",
                        "R.R. Martin",
                        "1948-09-20"});
            table1.AddRow(new string[] {
                        "17",
                        "J.K.",
                        "Rowling",
                        "1965-07-31"});
#line 4
 await testRunner.GivenAsync("une liste d\'auteurs", ((string)(null)), table1, "Given ");
#line hidden
        }
        
        async System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
        {
            await this.TestInitializeAsync();
        }
        
        async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
        {
            await this.TestTearDownAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Add a book")]
        [Xunit.TraitAttribute("FeatureTitle", "Books management")]
        [Xunit.TraitAttribute("Description", "Add a book")]
        public async System.Threading.Tasks.Task AddABook()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Add a book", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 10
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 3
await this.FeatureBackgroundAsync();
#line hidden
#line 11
 await testRunner.GivenAsync("un livre", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 12
 await testRunner.AndAsync("son titre est \"Le Seigneur des Anneaux\"", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 13
 await testRunner.AndAsync("l id de son auteur est 15", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 14
 await testRunner.AndAsync("sa date de publication est 1954-07-29", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 15
 await testRunner.WhenAsync("j ajoute le livre", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 16
 await testRunner.ThenAsync("le livre est ajoute", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Add a book without author exist")]
        [Xunit.TraitAttribute("FeatureTitle", "Books management")]
        [Xunit.TraitAttribute("Description", "Add a book without author exist")]
        public async System.Threading.Tasks.Task AddABookWithoutAuthorExist()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Add a book without author exist", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 18
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 3
await this.FeatureBackgroundAsync();
#line hidden
#line 19
 await testRunner.GivenAsync("un livre", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 20
 await testRunner.AndAsync("son titre est \"Le Seigneur des Anneaux\"", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 21
 await testRunner.AndAsync("l id de son auteur est 30", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 22
 await testRunner.WhenAsync("j ajoute le livre", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 23
 await testRunner.ThenAsync("une exception NotFound est retournee", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Add the same book twice")]
        [Xunit.TraitAttribute("FeatureTitle", "Books management")]
        [Xunit.TraitAttribute("Description", "Add the same book twice")]
        public async System.Threading.Tasks.Task AddTheSameBookTwice()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Add the same book twice", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 25
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 3
await this.FeatureBackgroundAsync();
#line hidden
#line 26
 await testRunner.GivenAsync("un livre", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 27
 await testRunner.AndAsync("son titre est \"Le Seigneur des Anneaux\"", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 28
 await testRunner.AndAsync("l id de son auteur est 15", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 29
 await testRunner.AndAsync("sa date de publication est 1954-07-29", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 30
 await testRunner.WhenAsync("j ajoute le livre 2 fois", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 31
 await testRunner.ThenAsync("une errreur de validation est retournee", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Add a book with a future publication date")]
        [Xunit.TraitAttribute("FeatureTitle", "Books management")]
        [Xunit.TraitAttribute("Description", "Add a book with a future publication date")]
        public async System.Threading.Tasks.Task AddABookWithAFuturePublicationDate()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Add a book with a future publication date", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 33
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 3
await this.FeatureBackgroundAsync();
#line hidden
#line 34
 await testRunner.GivenAsync("un livre", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 35
 await testRunner.AndAsync("son titre est \"Le Seigneur des Anneaux\"", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 36
 await testRunner.AndAsync("l id de son auteur est 15", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 37
 await testRunner.AndAsync("la date de publication est ulterieure a la date actuelle", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 38
 await testRunner.WhenAsync("j ajoute le livre", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 39
 await testRunner.ThenAsync("une errreur de validation est retournee", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Add a list of books")]
        [Xunit.TraitAttribute("FeatureTitle", "Books management")]
        [Xunit.TraitAttribute("Description", "Add a list of books")]
        public async System.Threading.Tasks.Task AddAListOfBooks()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Add a list of books", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 41
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 3
await this.FeatureBackgroundAsync();
#line hidden
                global::Reqnroll.Table table2 = new global::Reqnroll.Table(new string[] {
                            "Title",
                            "Author Id",
                            "Publication Date"});
                table2.AddRow(new string[] {
                            "Le Seigneur des Anneaux",
                            "15",
                            "1954-07-29"});
                table2.AddRow(new string[] {
                            "Le Hobbit",
                            "15",
                            "1937-09-21"});
#line 42
 await testRunner.GivenAsync("une liste de livre", ((string)(null)), table2, "Given ");
#line hidden
#line 46
 await testRunner.WhenAsync("j ajoute la liste de livre", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 47
 await testRunner.ThenAsync("la liste de livre est ajoute", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : object, Xunit.IAsyncLifetime
        {
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
            {
                await BooksManagementFeature.FeatureSetupAsync();
            }
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
            {
                await BooksManagementFeature.FeatureTearDownAsync();
            }
        }
    }
}
#pragma warning restore
#endregion
