# Copyright (c) 2011, MOBICAGE NV
# All rights reserved.
# 
# Redistribution and use in source and binary forms, with or without
# modification, are permitted provided that the following conditions are met:
# 1. Redistributions of source code must retain the above copyright
#    notice, this list of conditions and the following disclaimer.
# 2. Redistributions in binary form must reproduce the above copyright
#    notice, this list of conditions and the following disclaimer in the
#    documentation and/or other materials provided with the distribution.
# 3. All advertising materials mentioning features or use of this software
#    must display the following acknowledgement:
#    This product includes software developed by the <organization>.
# 4. Neither the name of the <organization> nor the
#    names of its contributors may be used to endorse or promote products
#    derived from this software without specific prior written permission.
# 
# THIS SOFTWARE IS PROVIDED BY MOBICAGE NV ''AS IS'' AND ANY
# EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
# WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
# DISCLAIMED. IN NO EVENT SHALL MOBICAGE NV BE LIABLE FOR ANY
# DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
# (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
# LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
# ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
# (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
# SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

from wokkel.xmppim import MessageProtocol, AvailablePresence
from twisted.python import log
import logging
import base64
from twisted.words.xish import domish
from twisted.web.client import getPage

class ForwarderProtocol(MessageProtocol):

    def __init__(self, endpoint):
        MessageProtocol.__init__(self)
        self.endpoint = endpoint

    def connectionMade(self):
        log.msg("Connected to xmpp server!", logLevel=logging.INFO)

        # send initial presence
        self.send(AvailablePresence())

    def connectionLost(self, reason):
        log.msg("Disconnected to xmpp server!", logLevel=logging.INFO)

    def onMessage(self, msg):
        log.msg(str(msg.toXml()), logLevel=logging.DEBUG)
        from_ = msg["from"]
        if from_ != 'bot@callback.rogerth.at':
            log.msg('Wrong sender: %s' % from_)
            return
        for element in msg.children:
            if not element.uri == "mobicage:comm":
                log.msg("Skipping element with uri '%s'" % element.uri, logLevel=logging.INFO)
                continue
            if not element.name == "call":
                log.msg("Skipping element with name '%s'" % element.name, logLevel=logging.INFO)
                continue
            # Validate sik
            sik = element['sik']
            if not sik:
                log.msg("Skipping call without sik", logLevel=logging.WARNING)
                continue
            log.msg("Handling incomming call")
            json_string = base64.decodestring(element.children[0])
            log.msg(json_string)

            def forward(output):
                log.msg("Sending result")
                log.msg(output)
                response = base64.encodestring(output)
                reply = domish.Element((None, "message"))
                reply["to"] = msg["from"]
                reply["from"] = msg["to"]
                reply["type"] = 'normal'
                result = reply.addElement("result", defaultUri="mobicage:comm", content=response)
                result["sik"] = sik
                self.send(reply)

            d1 = getPage(self.endpoint,
                    headers={'Content-Type': 'application/json-rpc; charset="utf-8"',
                             'X-Nuntiuz-Service-Key': str(sik)},
                    method="POST",
                    postdata=unicode(json_string).encode('utf-8'))

            def process_error(output):
                log.err(output)

            d1.addCallback(forward)
            d1.addErrback(process_error)

