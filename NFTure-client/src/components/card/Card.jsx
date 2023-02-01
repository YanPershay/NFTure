import "./Card.css";
import picture from "./card_image.jpg";
import author from "./avatar2.jpg";
import owner from "./avatar1.jpg";

const Card = () => {
  return (
    <div className="card">
      <div className="picture">
        <img src={picture} alt="NFT"></img>
      </div>
      <div className="characteristics">
        <p className="pictureName">Cyber-Fly 2099</p>
        <div className="bids">
          <div className="titles">
            <p className="title">Current Bid</p>
            <p className="title">Highest Bid</p>
          </div>
          <div className="values">
            <p className="value">50 TON (140 USD)</p>
            <p className="value">100 TON (300 USD)</p>
          </div>
        </div>
        <div className="dateBlock">
          <i class="fa-regular fa-clock"></i>
          <p className="date"> Sale ends on March 1st, 2023. at 4:38 AM</p>
        </div>
        <hr class="solid"></hr>
        <div className="persons">
          <div className="person">
            <img className="avatar" src={author}></img>
            <div className="name">
              <p className="type">Creator</p>
              <p className="username">@jake_sully</p>
            </div>
          </div>
          <div className="person">
            <img className="avatar" src={owner}></img>
            <div className="name">
              <p className="type">Owner</p>
              <p className="username">@yan_pershay</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Card;
