// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.fff

//alert("bakso phone!!");
//var headings = document.getElementByClassName("h1");
/*var notif = alert("bakso phone!!");*/



//$(document).ready(function () {

//});

//let id = 0
//var app = new Vue({
//    el: '#app',
//    data: {
//        movies: [],
//        movie: {
//            title: '',
//            price: '',
//            hideCompleted: false,
//            todos: []
//        },
//        isEdit: false
//    },
//    created: function () {
//        this.getMovies();
//    },
//    methods: {
//        getMovies: function () {
//            var self = this;
//            $.ajax({
//                type: 'GET',
//                url: '/movies/getall',
//                success: function (res) {
//                    self.movies = res;
//                },
//                error: function (err) {
//                    console.log(err);
//                }
//            });
//        },
//        getMovieById: function (id) {
//            var self = this;
//            $.ajax({
//                type: 'GET',
//                url: '/movies/getbyid/' + id,
//                success: function (res) {
//                    self.movie = res;
//                    self.isEdit = true;
//                },
//                error: function (err) {
//                    console.log(err);
//                }
//            });
//        },
//        insertMovie: function () {
//            var self = this;
//            console.log(self.movie);
//            $.ajax({
//                type: 'POST',
//                url: '/movies/create',
//                contentType: 'application/json',
//                data: JSON.stringify(self.movie),
//                success: function (res) {
//                    console.log(res);
//                    self.getMovies();
//                    self.clearData();
//                },
//                error: function (err) {
//                    console.log(err.responseJSON);
//                }
//            });

//        },
//        updateMovie: function () {
//            var self = this;
//            $.ajax({
//                type: 'POST',
//                url: '/movies/update',
//                contentType: 'application/json',
//                data: JSON.stringify(self.movie),
//                success: function (res) {
//                    self.getMovies();
//                    self.clearData();
//                },
//                error: function (err) {
//                    console.log(err);
//                }
//            });
//        },
//        deleteMovie: function (id) {
//            var self = this;
//            $.ajax({
//                type: 'POST',
//                url: '/movies/delete/' + id,
//                success: function (res) {
//                    self.getMovies();
//                },
//                error: function (err) {
//                    console.log(err);
//                }
//            });
//        },
//        clearData: function () {
//            this.movie = {
//                title: '',
//                price: ''
//            };
//            this.isEdit = false;
//        },



var app = new Vue({
    el: '#app',
    data: {
        movies: [],
        movie: {
            title: '',
            price: '',
            done: false
        },
        isEdit: false,
        hideCompleted: false,
        titleFilter: '',
        priceFilter: ''
    },
    created: function () {
        this.getMovies();
    },
    methods: {
        getMovies: function () {
            var self = this;
            $.ajax({
                type: 'GET',
                url: '/movies/getall',
                success: function (res) {
                    self.movies = res;
                },
                error: function (err) {
                    console.log(err);
                }
            });
        },
        getMovieById: function (id) {
            var self = this;
            $.ajax({
                type: 'GET',
                url: '/movies/getbyid/' + id,
                success: function (res) {
                    self.movie = res;
                    self.isEdit = true;
                },
                error: function (err) {
                    console.log(err);
                }
            });
        },
        insertMovie: function () {
            var self = this;
            $.ajax({
                type: 'POST',
                url: '/movies/create',
                contentType: 'application/json',
                data: JSON.stringify(self.movie),
                success: function (res) {
                    self.getMovies();
                    self.clearData();
                },
                error: function (err) {
                    console.log(err.responseJSON);
                }
            });
        },
        updateMovie: function () {
            var self = this;
            $.ajax({
                type: 'POST',
                url: '/movies/update',
                contentType: 'application/json',
                data: JSON.stringify(self.movie),
                success: function (res) {
                    self.getMovies();
                    self.clearData();
                },
                error: function (err) {
                    console.log(err);
                }
            });
        },
        deleteMovie: function (id) {
            var self = this;
            $.ajax({
                type: 'POST',
                url: '/movies/delete/' + id,
                success: function (res) {
                    self.getMovies();
                },
                error: function (err) {
                    console.log(err);
                }
            });
        },
        clearData: function () {
            this.movie = {
                title: '',
                price: '',
                done: false
            };
            this.isEdit = false;
        }
    },
    computed: {
        filteredMovies() {
            return this.movies.filter(movie => {
                return movie.title.includes(this.titleFilter) &&
                    movie.price.toString().includes(this.priceFilter) &&
                    (!this.hideCompleted || !movie.done);
            });
        }
    }
});
        //updateMovie: function () {
        //    var self = this;
        //    $.ajax({
        //        type: 'PUT',
        //        url: '/movies/update',
        //        data: self.
        //    //count: 0,
            //text: "",
            //awesome: true,
            //newTodo: '',
            //hideCompleted: false,
            //todos: [
            //    { id: id++, text: 'Learn HTML', done: true },
            //    { id: id++, text: 'Learn JavaScript', done: true },
            //    { id: id++, text: 'Learn Vue', done: false }
            //]

            //newName: '',
            //newAge: '',
            //newHobby: '',
            //hideCompleted: false,
            //todos: [
            //    { id: id++, name: 'John Doe', age: 30, hobby: 'Programming', done: true },
            //    { id: id++, name: 'Jane Doe', age: 28, hobby: 'Reading', done: true },
            //    { id: id++, name: 'Jim Smith', age: 35, hobby: 'Travelling', done: false }
            //]

//    methods: {
//        //addTodo() {
//        //    this.todos.push({ id: id++, text: this.newTodo, done: false })
//        //    this.newTodo = ''
//        //},
//        //removeTodo(todo) {
//        //    this.todos = this.todos.filter((t) => t !== todo)
//        //},
//        addTodo() {
//            this.todos.push({ id: id++, name: this.newName, age: this.newAge, hobby: this.newHobby, done: false })
//            this.newName = ''
//            this.newAge = ''
//            this.newHobby = ''
//        },
//        removeTodo(todo) {
//            this.todos = this.todos.filter((t) => t !== todo)
//        },
        //getData() {
        //    var self = this;
        //    $.ajax({
        //        url: "https://localhost:7290/Movies",
        //        type: "GET",
        //        contentType: "application/json",
        //        dataType: "JSON",
        //        success: function (result) {
        //            for (var i = 0; i < result.length; i++)
        //                self.datas.push(result[i])
        //        }
        //        })
//        }
//    },
//    computed: {
//        //filteredTodos() {
//        //    return this.hideCompleted
//        //        ? this.todos.filter((t) => !t.done)
//        //        : this.todos
//        //},
//        filteredTodos() {
//            return this.hideCompleted
//                ? this.todos.filter((t) => !t.done)
//                : this.todos
//        }

//    }
//})


        //increment() {
        //    console.log("inside increment")
        //    this.count++
        //},
        //decrement() {
        //    console.log("inside decrement")
        //    this.count--
        //},
        //onInput(e) {
        //    this.text = e.target.value
        //},
        //toggle() {
        //    this.awesome = !this.awesome
        //},
        

    
    
