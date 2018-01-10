var HelloWorld = React.createClass({
    render: function () {
        return (
            <div>Hello Leah, this is our react component</div>
        );
    }
});
ReactDOM.render(
    <HelloWorld name = "World" />,
    document.getElementById('root')
);  