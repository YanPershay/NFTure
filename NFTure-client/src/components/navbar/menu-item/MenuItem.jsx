import "./MenuItem.css";

const MenuItem = (props) => {
  return (
    <div>
      <a href={props.item.url} className={props.item.className}>
        <i className={props.item.icon}></i>
        {props.item.title}
      </a>
    </div>
  );
};

export default MenuItem;
