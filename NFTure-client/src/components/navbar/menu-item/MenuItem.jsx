import "./MenuItem.css";
import { Link } from "react-router-dom";

const MenuItem = (props) => {
  return (
    <div>
      <Link to={props.item.url} className={props.item.className}>
        <i className={props.item.icon}></i>
        {props.item.title}
      </Link>
    </div>
  );
};

export default MenuItem;
