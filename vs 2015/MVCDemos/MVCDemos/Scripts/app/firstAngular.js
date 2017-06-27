var myApp = angular
            .module("appModule", [])
            .controller("appController", function ($scope) {
                var Profile = {
                    Name: "Gaurav H Rana",
                    Site: "http://ghrana.com",
                    Flair: "http://www.c-sharpcorner.com/members/satyaprakash-samantaray/flair.png"
                };
                $scope.Profile = Profile;
            });