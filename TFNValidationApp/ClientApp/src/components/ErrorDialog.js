import React, { Component } from 'react';
import { Modal } from 'react-bootstrap';

export class ErrorDialog extends Component {

    constructor(props) {
        super(props);
    }


    render() {
        const { showModal, handleOnClose, heading, errorMessage } = this.props;
        return (
            <div style={{ opacity: '1' }}>
                <Modal show={showModal} onHide={handleOnClose}>
                    <Modal.Header>
                        {heading && <Modal.Title >{heading}</Modal.Title>}
                    </Modal.Header>
                    <Modal.Body >
                        <div>{errorMessage}</div>
                        <button onClick={handleOnClose} > close</button>
                    </Modal.Body>
                </Modal>
            </div>
        );
    }
}
