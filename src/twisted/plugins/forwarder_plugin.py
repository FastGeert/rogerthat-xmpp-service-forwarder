#
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
#
from twisted.python import usage
from zope.interface.declarations import implements
from twisted.application.service import IServiceMaker, MultiService
from twisted.plugin import IPlugin

class Options(usage.Options):
    optParameters = [["account", "a", None, "Jabber account"],
                     ["password", "p", None, "Jabber password"],
                     ["uri", "u", None, "Uri to post requests"]]

class ServiceMaker(object):
    implements(IServiceMaker, IPlugin)
    tapname = "rogerthat_service_call_forwarder"
    description = "Rogerthat service call forwarder."
    options = Options

    def makeService(self, options):
        """
        Construct a TCPServer from a factory defined in myproject.
        """

        multi_service = MultiService()
        from wokkel.client import XMPPClient
        from twisted.words.protocols.jabber import jid
        import forwarder

        xmppclient = XMPPClient(jid.internJID(options["account"]), options["password"])
        xmppclient.logTraffic = False
        bot = forwarder.ForwarderProtocol(options["uri"])
        bot.setHandlerParent(xmppclient)
        multi_service.addService(xmppclient)

        return multi_service

serviceMaker = ServiceMaker()
